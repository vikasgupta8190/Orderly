var contact = {
    deleteConfirmationMessage: false,
    deleteContactUrl: false,
    deleteGroupUrl: false,
    editContactUrl: false,
    editGroupUrl: false,
    editContactText: false,
    editGroupText: false,
    showGroupId: false,
    init: function (deleteConfirmationMessage, deleteContactUrl,
        deleteGroupUrl, editContactUrl, editGroupUrl, editContactText,
        editGroupText, showGroupId) {
        this.deleteConfirmationMessage = deleteConfirmationMessage;
        this.deleteContactUrl = deleteContactUrl;
        this.deleteGroupUrl = deleteGroupUrl;
        this.editContactUrl = editContactUrl;
        this.editGroupUrl = editGroupUrl;
        this.editContactText = editContactText;
        this.editGroupText = editGroupText;
        this.showGroupId = showGroupId;
    },
    renderSvg: function (data, type, row, meta) {
        var html =
            '<div class="action-dots">'
            + '<div class="svg_container" onclick="contact.dot_actions(this)" data-target="#dot_actions_contact_' + data + '">'
            + '<svg width="16" height="16" viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg"><g opacity = "0.4" ><path fill-rule="evenodd" clip-rule="evenodd" d="M8 11.3333C7.26362 11.3333 6.66667 11.9303 6.66667 12.6667C6.66667 13.403 7.26362 14 8 14C8.73638 14 9.33334 13.403 9.33334 12.6667C9.33334 11.9303 8.73638 11.3333 8 11.3333ZM8 6.66667C7.26362 6.66667 6.66667 7.26362 6.66667 8C6.66667 8.73638 7.26362 9.33333 8 9.33333C8.73638 9.33333 9.33334 8.73638 9.33334 8C9.33334 7.26362 8.73638 6.66667 8 6.66667ZM8 2C7.26362 2 6.66667 2.59695 6.66667 3.33333C6.66667 4.06971 7.26362 4.66667 8 4.66667C8.73638 4.66667 9.33334 4.06971 9.33334 3.33333C9.33334 2.59695 8.73638 2 8 2Z" fill="#7D6880"></path></g></svg>'
            + '</div>'
            + '<div class="dot_actions" id="dot_actions_contact_' + data + '" style="display:none">'
            + '<ul>'
            + '<li onclick="contact.editContact(' + data + ');"><i class="fas fa-pencil-alt"></i></li>'
            + '<li onclick="contact.deleteContact(' + data + ');"><i class="fas fa-trash"></i></li>'
            + '</ul>'
            + '</div>'
            + '</div>'
        return html;
    },
    dot_actions: function (v) {
        $('.dot_actions').each(function () {
            if ($(this).is(':visible'))
                $(this).css('display', 'none');
        });
        var target = $(v).attr('data-target');
        $('' + target + '').toggle();
    },
    renderNameWithCoppyButton: function(data, type, row, meta) {
        return '<span class="f_400 contact_address coppyAddress">' + data + '</span>&nbsp;<svg onclick="coppyText(this)" data-val="' + data + '" data-clipboard-text="Coppied!"  width="16" height="16" viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg" >'
            + '<g clip-path="url(#clip0_1335_2625)">'
            + '<path d="M3.24669 15H8.75331C9.44148 15 10 14.3855 10 13.6283V6.37174C10 5.61454 9.44148 5 8.75331 5H3.24669C2.55852 5 2 5.61454 2 6.37174V13.6296C2 14.3868 2.55727 15 3.24669 15Z" stroke="#6B8068" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>'
            + '<path d="M6 4.77177V2.37155C6 1.61446 6.55566 1 7.24031 1H12.7597C13.4443 1 14 1.61446 14 2.37155V9.62845C14 10.3855 13.4443 11 12.7597 11H10.547" stroke="#6B8068" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path></g><defs><clipPath id="clip0_1335_2625">'
            + '<rect width="16" height="16" fill="white"></rect></clipPath></defs></svg >';
    },
    deleteContact: function(v) {
        if (confirm(this.deleteConfirmationMessage)) {
            var id = v;
            ajaxRequests.POST(this.deleteContactUrl + '?id=' + id + '',
                {},
                (response) => {
                    orderlyNotification.getNotificaitonHtml();
                    refresh_contact_grid();
                },
                (error) => {
                    orderlyNotification.getNotificaitonHtml();
                }
            )
        }
    },
    deleteGroup: function(v) {
        if (confirm(this.deleteConfirmationMessage)) {
            var id = v;
            ajaxRequests.POST(this.deleteGroupUrl + '?id=' + id + '',
                {},
                (response) => {
                    orderlyNotification.getNotificaitonHtml();
                    refresh_group_grid();
                },
                (error) => {
                    orderlyNotification.getNotificaitonHtml();
                }
            )
        }
    },
    renderAccordian: function (data, type, row, meta) {
        return '<div class="accordion-item" style="position: relative;">'
            + '<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse_' + row.id + '" aria-expanded="true" aria-controls="collapse_' + row.id + '">' + data + '</button>'
            + '<div id="collapse_' + row.id + '" class="accordion-collapse collapse" aria-labelledby="headingOne" data-bs-parent="#accordionExample">'
            + '<div class="accordion-body">'
            + this.getTableHtml(row)
            + '</div>'
            + '</div>'
            + '<i class="fas fa-pencil-alt cus_edit_icon" onclick="contact.editGroup(' + row.id + ')"></i>'
            + '<i class="fas fa-trash cus_delete_icon" onclick="contact.deleteGroup(' + row.id + ')"></i>'
            + '</div>';
    },
    getTableHtml: function (row) {
        var html = '<div class="table_bg contact_table">'
            + '<div class="table-responsive">'
            + '<table class="table table-hover">'
            + '<thead><tr><th scope="col" class="first_td">Name</th><th scope="col" class="second_td">Address</th><th scope="col" class="text-start third_td">Token</th>'
            + '</tr></thead>'
            + '<tbody>';
        $(row.contacts).each(function () {
            var name = this.name;
            var address = this.address;
            var token = this.token;
            var id = this.id
            html += '<tr><td class="first_td"> ' + name + '</td>'
                + '<td class="second_td">'
                + '<span class="f_400 contact_address">' + address + '</span>&nbsp;'
                + '<svg onclick="coppyText(this)" data-val="' + address + '" width="16" height="16" viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">'
                + '<g clip-path="url(#clip0_1335_2625)">'
                + '<path d="M3.24669 15H8.75331C9.44148 15 10 14.3855 10 13.6283V6.37174C10 5.61454 9.44148 5 8.75331 5H3.24669C2.55852 5 2 5.61454 2 6.37174V13.6296C2 14.3868 2.55727 15 3.24669 15Z" stroke="#6B8068" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>'
                + '<path d="M6 4.77177V2.37155C6 1.61446 6.55566 1 7.24031 1H12.7597C13.4443 1 14 1.61446 14 2.37155V9.62845C14 10.3855 13.4443 11 12.7597 11H10.547" stroke="#6B8068" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>'
                + '</g><defs><clipPath id="clip0_1335_2625"><rect width="16" height="16" fill="white"></rect></clipPath></defs></svg>'
                + '</td>'
                + '<td class="text-start third_td">'
                + '</td>'
                + '</tr>'
        })
        html += '</tbody></table></div></div>';
        return html;
    },
    editGroup: function (v) {
        window.location.href = this.editGroupUrl + "?id=" + v + "";
    },
    editContact: function(v) {
        window.location.href = this.editContactUrl +"?id=" + v + "";
    }
}
$(document).ready(function () {
    $('#table_group .dataTables_scrollHead').remove();
    if (window.location.pathname == contact.editContactUrl) {
        $("#contactModal").modal('show');
        $('#contactModal h4').html('').html(contact.editContactText)
    }

    if (window.location.pathname == contact.editGroupUrl) {
        $("#groupModal").modal('show');
        $("#" + contact.showGroupId + "").click();
        $('#groupModal h4').html('').html(contact.editGroupText)
    }

    $('#new-Group').submit(function (e) {
        e.preventDefault();
        var url = $(this).attr('action');
        ajaxRequests.POST(
            url,
            $(this).serialize(),
            (response) => {
                if (response.success) {
                    refresh_group_grid();
                    $(this).trigger("reset");
                }
                orderlyNotification.getNotificaitonHtml();
            },
            (error) => {
            }
        )
    });
    $('#' + contact.showGroupId + '').on('click', function () {
        if ($(this).is(':checked')) {
            $('#table_contacts').css('display', 'none');
            $('#table_group').css('display', 'block');
        } else {
            $('#table_contacts').css('display', 'block');
            $('#table_group').css('display', 'none');
        }
        refresh_contact_grid();
        refresh_group_grid();
    })
})

$(document).ready(function () {

    $("#ContactIds").kendoMultiSelect({
        animation: {
            open: {
                effects: "zoom:in",
                duration: 300
            }
        }
    });
   
});