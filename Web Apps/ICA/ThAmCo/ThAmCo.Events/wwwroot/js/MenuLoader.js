$(document).ready(function () {
	LoadMenu()
});

function LoadMenu() {

	var menuLists = $('[id^="MeunItems"]');

	menuLists.each(function () {

		var data = $(this).data("id");

		if (data != undefined) {

			var menuId = parseInt(data);

			GetMenuItemIds(menuId)
		}
	});

	FetchFoodItems()
}

function GetMenuItemIds(menuId) {
	$.ajax({
		url: 'https://localhost:7173/api/MenuFoodItems/' + menuId,
		type: "GET",
		crossDomain: true,
		async: false,
		success: function (results) {
			results.forEach(function (result) {
				$('#MeunItems' + result.menuId).append('<tr id="FoodItem' + result.foodItemId + '" data-id="' + result.foodItemId + ' style="bold=true" "><td> --- Removed Item --- </td><td> --- Removed Item --- </td></tr>')
			})
		},

		error: function (error) {
			alert("Unable to get menu items" + error);
		}
	});
}

function FetchFoodItems() {
	var returnItems = null

	$.ajax({
		url: 'https://localhost:7173/api/FoodItem/',
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