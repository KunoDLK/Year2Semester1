var menuId

$(document).ready(function () {

	FetchFoodItems()

	menuId = parseInt($('#Menu').data('id'))

	SetSelectedFoodItems(menuId)

	$('[id ^= "FoodCheckbox"]').change(function () {
		var id = parseInt($(this).data('id'))
		if ($(this).is(':checked')) {
			$.ajax({
				url: 'https://localhost:7173/api/MenuFoodItems/',
				type: "POST",
				crossDomain: true,
				data: JSON.stringify({
					"menuId": menuId,
					"foodItemId": id
				}),
				headers: {
					'Content-Type': 'application/json'
				},

				error: function (error) {
					alert("Failed to add item to menu" + error);
				}
			});
		}
		else {
			$.ajax({
				url: 'https://localhost:7173/api/MenuFoodItems/',
				type: "DELETE",
				crossDomain: true,
				data: JSON.stringify({
					"menuId": menuId,
					"foodItemId": id
				}),
				headers: {
					'Content-Type': 'application/json'
				},
				error: function (error) {
					alert("Failed to remove item from menu" + error);
				}
			});
		}
	});
});

function SetSelectedFoodItems(menuId) {
	$.ajax({
		url: 'https://localhost:7173/api/MenuFoodItems/' + menuId,
		type: "GET",
		crossDomain: true,
		async: false,
		success: function (results) {
			results.forEach(function (result) {
				$('#FoodCheckbox' + result.foodItemId).prop('checked', true);
			})
		},

		error: function (error) {
			alert("Unable to get menu items" + error);
		}
	});
}

function FetchFoodItems() {
	$.ajax({
		url: 'https://localhost:7173/api/FoodItems/',
		type: "GET",
		crossDomain: true,
		async: false,
		success: function (result) {

			SetFoodItems(result)
		},
		error: function (error) {
			alert("Unable to load food items." + error);
		}
	});
}

function SetFoodItems(fooditems) {
	fooditems.forEach(function (foodItem) {

		$('#Menu').append('<tr><td><input id="FoodCheckbox'+ foodItem.foodItemId +'" data-id="'+ foodItem.foodItemId +'" type="checkbox"/></td><td>' + foodItem.description + "</td><td>" + foodItem.unitPrice + "</td></tr>");
	})
}
	