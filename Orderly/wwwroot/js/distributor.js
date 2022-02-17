var distributor = {
    saveDistributionUrl: false,
    groupIds:false,
    init: function (saveDistributionUrl,groupIds) {
        this.saveDistributionUrl = saveDistributionUrl;
        this.groupIds = groupIds;
    },
    addAdditionalAddr: function () {
        $(".additional-address").append($("#address-div").html());
    },
    removeAddress: function (id, v) {
        if (id !== null) {
            Delete(id, v);
        }
        else {
            $(v).parent().remove();
        }
    },
    saveAddress: function() {
        if (this.validateFields()) {
            var distributorAddresses = this.getData();
            console.log(distributorAddresses);
            ajaxRequests.POST(
                this.saveDistributionUrl
                , { distributorAddresses: distributorAddresses },
                (result) => {
                    if (result.status) {
                        var id = $('#ValidateAddressModal').attr('data-bs-id');
                        showPopup($('.sp_cards_inner.sp_card_fill_address[data-bs-id="' + id + '"]'))
                    }
                    orderlyNotification.getNotificaitonHtml();
                    //pageReload(3);
                });
        }
    },
    validateFields: function () {
        var valid = true;
        var regex = /^0x[a-fA-F0-9]{40}$/;
        $('#distributorAddressModal input[data-target="address"]').each(function () {
            valid = regex.test($(this).val())
            if (!valid) {
                $(this).attr('data-varified', 'false');
                $(this).parent().find('.validation').html("Invalid Address");
                $(this).parent().find('.validation').addClass('text-danger');
                $(this).parent().find('.validation').removeClass('text-success');
            }
        });

        if ($("#chkGroup").is(":checked")) {
            if ($.trim($("#groupName").val()).length == 0) {
                valid = false;
                $('.group-validation').html("This field is required.");
            }
        }
        return valid;
    },
    getData: function () {
        var obj = {};
        var data = [];
        var id = $('#distributorAddressModal').attr('data-bs-id');
        $('.address-modal .address-inner-div').each(function () {
            var addressId = $(this).attr('data-id');
            if (!addressId) {
                addressId = 0;
            }
            var alies = $(this).find('input[data-target="alies"]').val();
            var address = $(this).find('input[data-target="address"]').val();
            data.push({
                Alias: alies,
                Name: address,
                Id: addressId
            });
        });
        var groupName = "";
        if ($("#chkGroup").is(":checked")) {
            groupName = $.trim($("#groupName").val());
        }
        obj.Addresses = data;
        obj.Group = $("#chkGroup").is(":checked");
        obj.GroupId = $("#txtGroup").val();
        obj.GroupName = groupName;
        return obj;
    },
    renderHexWithDots: function (data, type, row, meta) {
        return this.sliceHexString(data)
    },
    sliceHexString: function (data) {
        return data.slice(0, 7) + '.....' + data.slice(data.length - 7, data.length)
    },
    renderQuantity: function (data, type, row, meta) {
        return '' + data + ' ' + row.quantityPostfix + '<span class="holding_btc"> $' + row.dollarAmount + '</span>';
    },
    renderToDiv: function (data, type, row, meta) {

        var text = 'OUT'
        var className = 'cus_out'
        if (row.in) {
            text = 'IN'
            className = 'cus_in'
        }
        return '<span class="' + className + '">' + text + '</span>' + this.sliceHexString(data) + '';
    },
    setFilter: function (type) {
        $("#FilterType").val(type);
        refresh_transaction_details_grid();
    },
    bindTotalDistributedAndToBeDistributedCount: function (data) {
        $('#total-distributed').html('').html('$' + data.totalDisributed.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
        if (data.totalToBeDisributed > 0)
            $('#to-be-distributed').html('').html('$' + data.totalToBeDisributed.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
        else
            $('#to-be-distributed').html('').html('$0');
    },
    getAddress: function() {
        if ($('#Address').val() != '') {
            refresh_transaction_details_grid();
        }
    }
}

$(document).ready(function () {
    $("#chkGroup").click(function () {
        if (!$(this).is(":checked")) {
            if (!$(".makegroup").hasClass("d-none")) {
                $(".makegroup").addClass("d-none");
            }
        }
        else {
            if ($(".makegroup").hasClass("d-none")) {
                $(".makegroup").removeClass("d-none");
            }
        }
    });
    $("#groupName").keypress(function () {
        $('.group-validation').html("");
    });
    $('#distributePopup').on('click', function () {
        $('#distribute_popup_model').toggle();
    });
    $('#new-contact').submit(function (e) {
        e.preventDefault();
        var url = $(this).attr('action');
        ajaxRequests.POST(
            url,
            $(this).serialize(),
            (response) => {               
                if (response.success) {
                    refresh_contact_grid();
                    $(this).trigger("reset");
                }
                orderlyNotification.getNotificaitonHtml();
            },
            (error) => {
            }
        )
    });
    $('#' + this.groupIds+'').kendoMultiSelect({
        animation: {
            open: {
                effects: "zoom:in",
                duration: 300
            }
        }
    });
});