var monitoring = {
    deleteConfirmationMessage: false,
    deleteUrl: false,
    allChangeConfirmation: false,
    updateNotificationURL: false,
    turnOnOffTokenGenerationUrl: false,
    turnOnOffIncommingUrl: false,
    updateShowOnPortfolioUrl: false,
    init: function (deleteConfirmationMessage, deleteUrl,
        allChangeConfirmation, updateNotificationURL,
        turnOnOffTokenGenerationUrl, turnOnOffIncommingUrl,
        updateShowOnPortfolioUrl) {
        this.deleteConfirmationMessage = deleteConfirmationMessage;
        this.deleteUrl = deleteUrl;
        this.allChangeConfirmation = allChangeConfirmation;
        this.updateNotificationURL = updateNotificationURL;
        this.turnOnOffTokenGenerationUrl = turnOnOffTokenGenerationUrl;
        this.turnOnOffIncommingUrl = turnOnOffIncommingUrl;
        this.updateShowOnPortfolioUrl = updateShowOnPortfolioUrl;
    },
    renderIncommingTokenBellIcon: function (data, type, row, meta) {
        var string = "'";
        if (data)
            return '<i class="fas fa-bell" onclick="monitoring.turnOnOfIncommingNotification(this,' + row.id + ',' + string + meta.settings.sTableId + string + ')"></i>';
        else
            return '<i class="far fa-bell" onclick="monitoring.turnOnOfIncommingNotification(this,' + row.id + ',' + string + meta.settings.sTableId + string + ')"></i>';
    },
    renderTokenGenerationBellIcon: function (data, type, row, meta) {
        var string = "'";
        if (data)
            return '<i class="fas fa-bell" onclick="monitoring.turnOnOfTokenGenerationNotification(this,' + row.id + ',' + string + meta.settings.sTableId + string + ')"></i>';
        else
            return '<i class="far fa-bell" onclick="monitoring.turnOnOfTokenGenerationNotification(this,' + row.id + ',' + string + meta.settings.sTableId + string + ')"></i>';
    },
    showOnPortfolio: function (v, id, grid) {
        if ($(v).hasClass('fas fa-bookmark')) {
            $(v).removeClass('fas fa-bookmark')
            $(v).addClass('far fa-bookmark')
        } else {
            $(v).removeClass('far fa-bookmark')
            $(v).addClass('fas fa-bookmark')
        }
        var enable = $('#show_in_portfolio_' + id + '').hasClass('fas')
        ajaxRequests.POST(this.updateShowOnPortfolioUrl,
            { id: id, enable: enable },
            (response) => {
                orderlyNotification.getNotificaitonHtml();
                $('#' + grid + '').DataTable().ajax.reload();
            },
            (error) => {

            })
    },
    deleteAll: function (id) {
        if (confirm(this.deleteConfirmationMessage)) {
            ajaxRequests.POST(this.deleteUrl,
                { id: id },
                (response) => {
                    if (response.success)
                        window.location.reload();
                },
                (error) => {

                });
        }
    },
    notification: function (id, grid) {
        if (confirm(this.allChangeConfirmation)) {
            var enable = $('#notification_' + id + '').is(':checked');
            ajaxRequests.POST(this.updateNotificationURL,
                { id: id, enable: enable },
                (response) => {
                    orderlyNotification.getNotificaitonHtml();
                    $('#' + grid + '').DataTable().ajax.reload();
                },
                (error) => {

                })
        } else {
            $('#notification_' + id + '').prop('checked', !$('#notification_' + id + '').is(':checked'))
        }
    },
    turnOnOfTokenGenerationNotification: function (v, id, network) {
        if ($(v).hasClass('fas fa-bell')) {
            $(v).removeClass('fas fa-bell')
            $(v).addClass('far fa-bell')
        } else {
            $(v).removeClass('far fa-bell')
            $(v).addClass('fas fa-bell')
        }
        var enable = $(v).hasClass('fas')
        ajaxRequests.POST(this.turnOnOffTokenGenerationUrl,
            { id: id, enable: enable },
            (response) => {
                orderlyNotification.getNotificaitonHtml();
                $('#' + network.trim() + '').DataTable().ajax.reload();
            },
            (error) => {

            })
    },
    turnOnOfIncommingNotification: function (v, id, network) {
        if ($(v).hasClass('fas fa-bell')) {
            $(v).removeClass('fas fa-bell')
            $(v).addClass('far fa-bell')
        } else {
            $(v).removeClass('far fa-bell')
            $(v).addClass('fas fa-bell')
        }
        var enable = $(v).hasClass('fas')
        ajaxRequests.POST(this.turnOnOffIncommingUrl,
            { id: id, enable: enable },
            (response) => {
                orderlyNotification.getNotificaitonHtml();
                $('#' + network.trim() + '').DataTable().ajax.reload();
            },
            (error) => {

            })
    }
}