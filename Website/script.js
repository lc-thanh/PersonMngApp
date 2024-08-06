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