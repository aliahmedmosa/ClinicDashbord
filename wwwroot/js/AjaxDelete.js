
$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);

	/*this is the code of bootbox*/
        bootbox.confirm({
            message: 'are you sure you want to delete this item ?',
            buttons: {
                cancel: {
                    label: '<i class="fa fa-times"></i> Cancel',
                    className: 'btn-info'
                },
                confirm: {
                    label: '<i class="fa fa-check"></i> Delete',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {
                    $.ajax({
                        url: '/'+btn.data('controller')+'/Delete/' + btn.data('id'),
                        success: function () {
                            btn.parents('.Item-row').fadeOut();
                            toastr.error("Successfully deleted !") 
                        },
                        error: function () {
                            toastr.error("Something went rong !")
                        }
                    });
                }
            }
        });
	
	/*End code of bootbox*/
    

	});
});