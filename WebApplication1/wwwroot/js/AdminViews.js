$(document).ready(function () {
	//// Activate tooltip
	//$('[data-ztoggle="tooltip"]').tooltip();

	// Select/Deselect checkboxes
	var checkbox = $('table tbody input[type="checkbox"]');
	$("#selectAll").click(function () {
		if (this.checked) {
			checkbox.each(function () {
				this.checked = true;
			});
		} else {
			checkbox.each(function () {
				this.checked = false;
			});
		}
	});
	checkbox.click(function () {
		if (!this.checked) {
			$("#selectAll").prop("checked", false);
		}
	});
});



const table = document.getElementById('userTable');

table.addEventListener('click', (e) => {
	if (e.target.tagName !== 'I') return;
	const head = table.tHead.rows[0].cells
	const tr = e.target.closest('tr');

	if (e.target.dataset.type == 'edit') editRow(head, tr);
	if (e.target.dataset.type == 'delete') deleteRow(tr);
});

function editRow(head, tr) {
	const current = {};
	for (let i = 0; i < tr.cells.length - 1; i++) {
		current[head[i].innerText] = tr.cells[i].innerText
	}
	showModal(current)
}

//function deleteRow(tr) {
//	var _customer = {};
//	_customer.CustomerId = tr;
//	//_customer.CustomerId = $("#txtCustomerId").val();
//	$.ajax({
//		type: "POST",
//		url: "/Item/Delete",
//		data: JSON.stringify(_customer),
//		contentType: "application/json; charset=utf-8",
//		dataType: "json",
//		success: function (customer) {
//			if (customer != null) {
//				alert("Deleted Customer: " + customer.Name);
//			} else {
//				alert("Customer record not found.");
//			}
//		}
//	});
//	tr.remove();
	
//}

function showModal(editData) {
	var data = editData;
	$(".modal-body #itemName").val(data.Name);
	$(".modal-body #itemPrice").val(data.Price); 
	$(".modal-body #itemType").val(data.ItepType);
	$(".modal-body #itemVendorCode").val(data.VendorCode);
	$('#editItemModal').modal('show');
}


//$("body").on("click", "#btnDelete", function () {
//	if (confirm("Do you want to delete this Customer?")) {
//		var _customer = {};
//		_customer.CustomerId = $("#txtCustomerId").val();
//		$.ajax({
//			type: "POST",
//			url: "/Home/DeleteCustomer",
//			data: JSON.stringify(_customer),
//			contentType: "application/json; charset=utf-8",
//			dataType: "json",
//			success: function (customer) {
//				if (customer != null) {
//					alert("Deleted Customer: " + customer.Name);
//				} else {
//					alert("Customer record not found.");
//				}
//			}
//		});
//	}
//});