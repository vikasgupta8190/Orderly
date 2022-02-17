var ajaxLoader = {
    show: function () {
        $('#ajaxLoader').addClass('visible').show();
    },
    hide: function () {
        $('#ajaxLoader').removeClass('visible').hide();
    }
}

var orderlyNotification = {   
    getNotificaitonHtml: function () {
        ajaxRequests.GET('/notificationMessage',
            (response) => {
                $('.center_panel').children().first().before(response)
            },
            (error) => {
                
            }
        )
    }
}

var ajaxRequests = {
    POST: function (url, data, successfunc, errorfunc) {
        ajaxLoader.show();
        addAntiForgeryToken(data);
        $.ajax({
            url: url,
            data: data,
            type: "POST",
            success: function (response) {
                successfunc(response)
            },
            complete: function () {
                ajaxLoader.hide()
            },
            error: function (response) {
                ajaxLoader.hide()
                errorfunc()
            }
        });
    },
    POSTWithoutLoader: function (url, data, successfunc, errorfunc) {        
        addAntiForgeryToken(data);
        $.ajax({
            url: url,
            data: data,
            type: "POST",
            success: function (response) {
                successfunc(response)
            },
            complete: function () {              
            },
            error: function (response) {               
                errorfunc()
            }
        });
    },
    GET: function (url, successfunc, errorfunc) {
        ajaxLoader.show();

        $.ajax({
            url: url,
            type: "GET",
            success: function (response) {
                successfunc(response)
            },
            complete: function () {
                ajaxLoader.hide()
            },
            error: function (response) {
                ajaxLoader.hide()
                errorfunc()
            }
        });
    },
    GETWithoutLoader: function (url, successfunc, errorfunc) {        
        $.ajax({
            url: url,
            type: "GET",
            success: function (response) {
                successfunc(response)
            },
            complete: function () {               
            },
            error: function (response) {               
                errorfunc()
            }
        });
    }
}

// CSRF (XSRF) security
function addAntiForgeryToken(data) {
    //if the object is undefined, create a new one.
    if (!data) {
        data = {};
    }
    //add token
    var tokenInput = $('input[name=__RequestVerificationToken]');
    if (tokenInput.length) {
        data.__RequestVerificationToken = tokenInput.val();
    }
    return data;
};

var entityMap = {
    '&': '&amp;',
    '<': '&lt;',
    '>': '&gt;',
    '"': '&quot;',
    "'": '&#39;',
    '/': '&#x2F;',
    '`': '&#x60;',
    '=': '&#x3D;'
};

function escapeHtml(string) {
    if (string == null) {
        return '';
    }
    return String(string).replace(/[&<>"'`=\/]/g, function (s) {
        return entityMap[s];
    });
}

//selectedIds - This variable will be used on views. It can not be renamed
var selectedIds = [];


function clearMasterCheckbox(tableSelector) {
    $($(tableSelector).parents('.dataTables_scroll').find('input.mastercheckbox')).prop('checked', false).change();
    selectedIds = [];
}


function updateMasterCheckbox(tableSelector) {
    var selector = 'mastercheckbox';
    var numChkBoxes = $('input[type=checkbox][class!=' + selector + '][class=checkboxGroups]', $(tableSelector)).length;
    var numChkBoxesChecked = $('input[type=checkbox][class!=' + selector + '][class= checkboxGroups]:checked', $(tableSelector)).length;

    $('.mastercheckbox', $(tableSelector)).prop('checked', numChkBoxes == numChkBoxesChecked && numChkBoxes > 0);
}

function updateTableSrc(tableSelector, isMasterCheckBoxUsed) {
    var dataSrc = $(tableSelector).DataTable().data();
    $(tableSelector).DataTable().clear().rows.add(dataSrc).draw();
    $(tableSelector).DataTable().columns.adjust();

    if (isMasterCheckBoxUsed) {
        clearMasterCheckbox(tableSelector);
    }
}


function updateTable(tableSelector, isMasterCheckBoxUsed) {
    $(tableSelector).DataTable().ajax.reload();
    $(tableSelector).DataTable().columns.adjust();

    if (isMasterCheckBoxUsed) {
        clearMasterCheckbox(tableSelector);
    }
}


function updateTableWidth(tableSelector) {
    if ($.fn.DataTable.isDataTable(tableSelector)) {
        $(tableSelector).DataTable().columns.adjust();
    }
}

function coppyText(v) {
    $('.tooltiptext').remove();
    var sampleTextarea = document.createElement("textarea");
    document.body.appendChild(sampleTextarea);
    sampleTextarea.value = $(v).attr('data-val'); //save main text in it
    sampleTextarea.select(); //select textarea contenrs
    document.execCommand("copy");
    document.body.removeChild(sampleTextarea);
    $(v).after('<span class="tooltiptext">- Coppied</span>')
    setTimeout(function () {
        $('.tooltiptext').remove();
    }, 1000);
}