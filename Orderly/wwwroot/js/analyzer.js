analyzer = {
    showLabel: false,
    distributionTransactionsUrl: false,
    filtersDataUrl: false,
    init: function (showLabel, distributionTransactionsUrl,
        filtersDataUrl) {
        this.showLabel = showLabel;
        this.distributionTransactionsUrl = distributionTransactionsUrl;
        this.filtersDataUrl = filtersDataUrl;
    },
    renderValueWithPercentageSign: function (data, type, row, meta) {
        return '<label>' + data + ' %</label>'
    },
    renderInvestedAmountWithPriceAndQuantity: function (data, type, row, meta) {
        return '<div class="investment-amount row"> <div class="col-2 investment-grid-icons">' + row.investedNetworkIcon + '</div>'
            + '<ul class="col-10">'
            + '<li>' + row.investedQuantity.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + ' ' + row.investementAbbrivation + '</li>'
            + '<li><span>$' + data.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + '</span></li>'
            + '</ul>'
            + '</div>'
    },
    renderToggleMenuWithSubTable: function (data, type, row, meta) {
        return '<a href="javascript:void(0);" data-val="' + data + '" data-toggle="collapse" data-target="#investment-distribution-' + row.monitoringTypeId + '-' + data + '_' + row.id + '" aria-expanded="true" aria-controls="investment-distribution-' + row.monitoringTypeId + '-' + data + '" onclick="analyzer.openDistribution(' + row.monitoringTypeId + ',' + row.id + ',this)">' + this.showLabel + '</a>'
    },
    openDistribution: function (networkId, id, v) {
        var txHash = $(v).attr('data-val');
        var divSelector = 'investment-distribution-' + networkId + '-' + txHash + '_' + id + '';
        if ($('#' + divSelector + '').length <= 0) {
            ajaxRequests.GET(this.distributionTransactionsUrl + '?txHash=' + txHash + '&networkId=' + networkId + '&id=' + id + '',
                (response) => {
                    response = response.replace('&amp;', '&')
                    var selector = $(v).parents('tr').first();
                    $(selector).after('<tr class="collapse show" aria-labelledby="headingOne"><td id="' + divSelector + '" colspan="5">' + response + '</td><tr>')
                },
                (error) => {

                }
            )
        } else {
            $('#' + divSelector + '').parents('tr').first().toggle()
        }
    },
    RenderSubTableColumn: function (data, type, row, meta) {
        return '<ul><li>' + data + ' ' + row.networkAbbrivation + '</li><li>$' + row.value + '</li></ul>'
    },
    sliceHexString: function (data) {
        return data.slice(0, 7) + '.....' + data.slice(data.length - 7, data.length)
    },
    renderHexWithDots: function (data, type, row, meta) {
        return this.sliceHexString(data)
    },
    filters: function (obj) {
        var value = parseInt($(obj).val());
        if (isNaN(value)) { value = 0; }

        if (value > 0) {
            if ($("#filtersValues").hasClass("d-none")) {
                $("#filtersValues").removeClass("d-none");
            }
            this.bindFilterData(value);
        } else {
            if (!$("#filtersValues").hasClass("d-none")) {
                $("#filtersValues").addClass("d-none");
            }
            $("#FilterValue").val(0);
            $("#FilterType").val(0);
            refresh_analyzer_grid();
        }
    },
    bindFilterData: function (filterType) {
        ajaxRequests.GET(this.filtersDataUrl + '?type=' + filterType + '',
            (response) => {
                if (response.success) {
                    var html = "<option value>Select</option>";
                    $.each(response.result, function (key, option) {
                        html += "<option value=" + option.value + " >" + option.text + "</option>";
                    });
                    $("#filtersValues").html(html);
                    $("#FilterType").val(filterType);
                }
            },
            (error) => {

            }
        )
    },
    filterTypeOptions: function (obj) {
        var optionValue = parseInt($(obj).val());
        if (isNaN(optionValue)) { optionValue = 0; }
        if (optionValue > 0) {
            $("#FilterValue").val(optionValue);
            refresh_analyzer_grid();
        }
    },
    bindTotalInvestedAmount: function (data) {
        $('#wholeInvestedAmount').html('$' + data.wholeTimeInvestedAmount);
        $('#currentAmountOfInvestedAmt').html('$' + data.currentAmountOfInvestedAmt);
        $("#profit-loss").html(data.profitLossOnInvestment);
    }
}