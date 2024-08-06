$(document).ready(function () {
    var table = $('#personTable').DataTable({
        ajax: {
            url: 'https://localhost:44321/api/v1/Persons',
            dataType: "json",
            dataSrc: '',
        },
        columns: [
            { data: null },
            { data: 'fullName' },
            { data: 'phoneNumber', orderable: false },
            { data: 'emailAddress', orderable: false },
            { data: 'role' },
            { data: 'address' },
            {
                data: null,
                render: function (data, type, row) {
                    return `<button class="btn btn-sm btn-warning editBtn" data-id="${data.id}">Sửa</button>
                                    <button class="btn btn-sm btn-danger deleteBtn" data-id="${data.id}">Xóa</button>`;
                }
            }
        ],
        createdRow: function (row, data, dataIndex) {
            // Set the index column value
            $(row).find('td:eq(0)').html(dataIndex + 1);
        },
        retrieve: true,
        processing: true,
        language: {
            info: 'Trang _PAGE_/_PAGES_',
            search: 'Tìm kiếm:',
            lengthMenu: '_MENU_ dữ liệu trong 1 trang',
            zeroRecords: 'Không có dữ liệu nào',
            processing: 'Đang tải...',
            loadingRecords: 'Không có dữ liệu nào'
        },
    });

    // Handle Add Person button click
    $('#addPersonBtn').on('click', function () {
        $('#addPersonModal').modal('show');
    });

    // Handle role change
    $('#role').on('change', function () {
        var role = $(this).val();
        if (role === 'Student') {
            $('#studentFields input').attr('required', 'required');
            $('#studentFields').show();
            $('#professorFields').hide();
            $('#professorFields  input').removeAttr('required');
        } else if (role === 'Professor') {
            $('#studentFields').hide();
            $('#studentFields  input').removeAttr('required');
            $('#professorFields  input').attr('required', 'required');
            $('#professorFields').show();
        } else {
            $('#studentFields').hide();
            $('#professorFields').hide();
        }
    });

    // Call POST api
    $('#addPersonForm').on('submit', function (event) {
        event.preventDefault();

        function safeParseFloat(value) {
            var result = parseFloat(value);
            return isNaN(result) ? 0 : result;
        }

        var newPerson = {
            fullName: $('#name').val(),
            phoneNumber: $('#phone').val(),
            emailAddress: $('#email').val(),
            role: $('#role').val(),
            address: $('#address').val(),
            studentNumber: $('#studentId').val(),
            averageMark: safeParseFloat($('#gpa').val()),
            salary: safeParseFloat($('#salary').val())
        };

        console.log(newPerson);
        

        // Send data to API
        $.ajax({
            url: 'https://localhost:44321/api/v1/Persons', // Replace with your API endpoint
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(newPerson),
            success: function (response) {
                alert(response);

                // Reload DataTable
                table.ajax.reload();

                // Hide modal and reset form
                $('#addPersonModal').modal('hide');
                $('#addPersonForm')[0].reset();
                $('#studentFields').hide();
                $('#professorFields').hide();
            },
            error: function () {
                alert('Failed to add person.');
            }
        });
    });

    // Handle Edit button click
    $('#personTable tbody').on('click', '.editBtn', function () {
        var id = $(this).data('id');
        alert(id);
    });

    // Handle Delete button click
    $('#personTable tbody').on('click', '.deleteBtn', function () {
        var id = $(this).data('id');
        alert(id);
    });
});