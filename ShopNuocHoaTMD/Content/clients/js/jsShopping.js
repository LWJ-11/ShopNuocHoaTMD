$(document).ready(function () {
    showCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quatity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '') {

            quatity = parseInt(tQuantity);
        }

        $.ajax({
            url: '/shoppingcart/addtocart',
            type: 'POST',
            data: { id: id, quantity: quatity },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.count);
                    toastr.optionsOverride = 'positionclass = "toast-bottom-full-width"';
                    toastr.options.positionClass = 'toast-bottom-right';
                    toastr.success(rs.msg);
                }
            }   
        });
    });
    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        toastr.warning("<br /><button type='button' id='confirmationButtonYes' class='btn clear' style='margin:0px;'>Yes</button>", 'Do you want to remove all items in bag?',
            {
                closeButton: false,
                allowHtml: true,
                onShown: function (toast) {
                    $("#confirmationButtonYes").click(function () {
                        $.ajax({
                            url: '/shoppingcart/delete',
                            type: 'POST',
                            data: { id: id },
                            success: function (rs) {
                                if (rs.Success) {
                                    $('#checkout_items').html(rs.count);
                                    $('#trow_' + id).remove();
                                    LoadCart();
                                }
                            }
                        })
                    });
                }
            });
    });
    $('body').on('click', '.btnDeleteAll', function (e) {
        e.preventDefault();
        toastr.warning("<br /><button type='button' id='confirmationButtonYes' class='btn clear'>Yes</button>", 'Do you want to remove all items in bag?',
            {
                closeButton: false,
                allowHtml: true,
                onShown: function (toast) {
                    $("#confirmationButtonYes").click(function () {
                        DeleteAll();
                    });
                }
            });
    });
    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data("id");
        var quantity = $('#Quantity_' + id).val();
        Update(id, quantity);
        toastr.optionsOverride = 'positionclass = "toast-bottom-full-width"';
        toastr.options.positionClass = 'toast-bottom-right';
        toastr.success('Item updated');
    });
});

function showCount() {
    $.ajax({
        url: '/shoppingcart/showcount',
        type: 'GET',
        success: function (rs) {
            $('#checkout_items').html(rs.count);
        }
    });
};
function DeleteAll() {
    $.ajax({
        url: '/shoppingcart/DeleteAll',
        type: 'POST',
        success: function (rs) {
            if (rs.Success){
                LoadCart();
            }
        }
    })
}

function Update(id, quantity) {
    $.ajax({
        url: '/shoppingcart/Update',
        type: 'POST',
        data: { id: id, quantity: quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    })
}


function LoadCart() {
    $.ajax({
        url: '/shoppingcart/Partial_Item_Cart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}