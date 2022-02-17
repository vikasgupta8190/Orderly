var setupPortfolioMonitoring = {
    filterCardUrl: false,
    deleteConfirmationMessage: false,
    deleteUrl: false,
    saveUrl: false,
    getPopupUrl: false,
    init: function (filterCardUrl,
        deleteConfirmationMessage,
        deleteUrl,
        saveUrl,
        getPopupUrl) {
        this.filterCardUrl = filterCardUrl;
        this.deleteConfirmationMessage = deleteConfirmationMessage;
        this.deleteUrl = deleteUrl;
        this.saveUrl = saveUrl;
        this.getPopupUrl = getPopupUrl;
    },
    filterPortfolioCards: function (v) {
        var searchText = $(v).val();
        ajaxRequests.GET(this.filterCardUrl + "?searchKey=" + searchText, this.renderPortfolioCards, this.showError)
    },
    renderPortfolioCards: function (res) {
        $('.sp_cards').remove();
        $('.sp_search').after(res);
    },
    showError: function (error) {

    },
    openLeftPanel: function (v) {
        this.showPopup(v);
    },
    addAdditionalAddress: function () {
        $(".address-modal").append($(".address-div").html());
        $('.add_address').removeAttr('onclick');
    },
    delete: function (id, v) {
        if (this.validateFields()) {
            var countDiv = $('.address-inner-div').length;
            if (id) {
                if (confirm(this.deleteConfirmationMessage)) {
                    ajaxRequests.POST(
                        this.deleteUrl + "?addressId=" + id + ""
                        , null,
                        (result) => {
                            if (result.status) {
                                if (countDiv > 2) {
                                    $(v).parent().remove();
                                    $('.add_address').attr('onclick', 'setupPortfolioMonitoring.addAdditionalAddress()');
                                }
                                var id = $('#ValidateAddressModal').attr('data-bs-id');
                                this.showPopup($('.sp_cards_inner.sp_card_fill_address[data-bs-id="' + id + '"]'))
                            }
                            orderlyNotification.getNotificaitonHtml();
                        });
                }
            }
        }
    },
    removeAddress: function (id, v) {
        if (id !== null) {
            this.delete(id, v);
        }
        else {
            $(v).parent().remove();
            $('.add_address').attr('onclick', 'setupPortfolioMonitoring.addAdditionalAddress()');
        }
    },
    validate: function (v) {
        if ($(v).val() != '') {
            $(v).parent().find('.validation').html('');
            var id = $('#ValidateAddressModal').attr('data-bs-id');
            var regex = /^0x[a-fA-F0-9]{40}$/;
            var valid = regex.test($(v).val())
            if (valid) {
                $(v).attr('data-varified', 'true');
                $(v).parent().find('.validation').html('Verified');
                $(v).parent().find('.validation').removeClass('text-danger');
                $(v).parent().find('.validation').addClass('text-success');
                $('.add_address').attr('onclick', 'setupPortfolioMonitoring.addAdditionalAddress()');
            } else {
                $(v).attr('data-varified', 'false');
                $(v).parent().find('.validation').html('Not Verified');
                $(v).parent().find('.validation').addClass('text-danger');
                $(v).parent().find('.validation').removeClass('text-success');
                $('.add_address').removeAttr('onclick');
            }
        }
    },
    savePortFolioMonitoring: function () {
        if (this.validateFields()) {
            var portFolios = this.getData();
            ajaxRequests.POST(
                this.saveUrl
                , { portFolios: portFolios },
                (result) => {
                    if (result.status) {
                        var id = $('#ValidateAddressModal').attr('data-bs-id');
                        this.showPopup($('.sp_cards_inner.sp_card_fill_address[data-bs-id="' + id + '"]'))
                    }
                    orderlyNotification.getNotificaitonHtml();
                });
        }
    },
    getData: function () {
        var data = [];
        var id = $('#ValidateAddressModal').attr('data-bs-id');
        $('.address-modal .address-inner-div').each(function () {
            var addressId = $(this).attr('data-id');
            if (!addressId) {
                addressId = 0;
            }
            var alies = $(this).find('input[data-target="alies"]').val();
            var address = $(this).find('input[data-target="address"]').val();
            var bnbCheckbox = false;
            if (id !== 1) {
                bnbCheckbox = $(this).find('#chkBNB').is(":checked");
            }
            data.push({
                AddressAlies: alies,
                Address: address,
                TypeId: id, //static for now
                Id: addressId,
                IsSameAddressForBNB: bnbCheckbox
            })
        })
        return data;
    },
    validateFields: function () {
        var valid = true;
        var regex = /^0x[a-fA-F0-9]{40}$/;
        $('#ValidateAddressModal input[data-target="address"]').each(function () {
            valid = regex.test($(this).val())
            if (!valid) {
                $(this).attr('data-varified', 'false');
                $(this).parent().find('.validation').html("Invalid Address");
                $(this).parent().find('.validation').addClass('text-danger');
                $(this).parent().find('.validation').removeClass('text-success');
            }
        });
        return valid;
    },
    showPopup: function (v) {
        var typeId = $(v).attr('data-bs-id')
        ajaxRequests.GET(this.getPopupUrl + "?typeId=" + typeId,
            (response) => {
                $('#ValidateAddressModal .modal-content').html('').html('' + response + '');
                var model = $(v).attr('data-bs-target');
                $('' + model + '').attr('data-bs-id', $(v).attr('data-bs-id'))
            }, () => {

            })
    }
}