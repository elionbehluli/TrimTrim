// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function fetchUsers() {
    $.ajax({
        url: '/api/admin/users', // Update the URL to your API endpoint for fetching users
        type: 'GET',
        success: function (data) {
            var userList = $('#userList');
            userList.empty(); // Clear previous content
            
            data.forEach(function (user) {
                console.log(user);
                var listItem = $('<li>');
                var checkbox = $('<input>', { type: 'checkbox', class: 'user-checkbox', 'data-user-id': user.id });
                listItem.append(checkbox);
                listItem.append($('<span>', { text: user.userName }));
                listItem.appendTo(userList);
            });
            
            // Show the modal
            $('#userSelectionModal').modal('show');
        },
        error: function (error) {
            console.error('Error fetching users:', error);
        }
    });
}

// Trigger the fetchUsers function when the Add Permission button is clicked
$('#addPermissionBtn').on('click', function () {
    fetchUsers();
});

// Handle user selection in the modal
$('#userList').on('click', 'li', function () {
    $(this).toggleClass('active').siblings().removeClass('active');
});

// Grant permission button click
$('#grantPermissionBtn').on('click', function () {
    // Retrieve the selected users from the modal
    var selectedUsers = $('#userList .user-checkbox:checked').map(function () {
        return {
            id: $(this).data('user-id'),
            name: $(this).closest('li').find('span').text()
        };
    }).get();

    // Display the selected users' information in the console
    console.log('Selected Users:', selectedUsers);

    // Get the product ID from the hidden input
    var productId = $('#productId').val();

    // Make an AJAX request to the backend endpoint, including the product ID
    $.ajax({
        url: '/api/admin/premissiongrant', // Update the URL to your backend endpoint
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ users: selectedUsers, productId: productId }),
        success: function (data) {
            console.log('Permissions granted successfully:', data);
        },
        error: function (error) {
            console.error('Error granting permissions:', error);
        }
    });

    // Close the modal
    $('#userSelectionModal').modal('hide');
});
$('#closePermissionBtn').on('click', function () {
    // Close the modal
    $('#userSelectionModal').modal('hide');
});