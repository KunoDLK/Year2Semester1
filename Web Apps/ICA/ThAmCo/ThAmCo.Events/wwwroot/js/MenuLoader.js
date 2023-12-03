$(document).ready(function () {

	$('[id^="MeunItems"]').each(function () {

		var menuId = parseInt($(this).data("id"));

		GetMenuItemIds(menuId)
	});

FetchFoodItems()
	
});

function GetMenuItemIds(menuId) {
	$.ajax({
		url: 'https://localhost:7173/api/MenuFoodItems/' + menuId,
		type: "GET",
		crossDomain: true,
		async: false,
		success: function (results) {
			results.forEach(function (result) {
				$('#MeunItems' + result.menuId).append('<tr id="FoodItem' + result.foodItemId + '" data-id="' + result.foodItemId + '"><td>' + result.foodItemId + '</td></tr>')
			})
		},

		error: function (error) {
			alert("Unable to get menu items" + error);
		}
	});
}

function FetchFoodItems() {
	var returnItems =null
	
	$.ajax({
		url: 'https://localhost:7173/api/FoodItems/',
		type: "GET",
		crossDomain: true,
		success: function (result) {

			SetFoodItems(result)
		},
		error: function (error) {
			alert("Unable to load food items." + error);
		}
	});

	return returnItems
}

function SetFoodItems(fooditems) {
	fooditems.forEach(function (foodItem) {
		$('[id=FoodItem' + foodItem.foodItemId + ']').each(function () {

			$(this).html("<td>" + foodItem.description + "</td><td>" + foodItem.unitPrice + "</td>");
		})
	})
}
