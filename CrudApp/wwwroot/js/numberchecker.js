var inputEl = document.getElementById('number-check');
var messageEl = document.getElementById('number-check-message');
var submitButton = document.querySelector('form input[type="submit"]');
inputEl.addEventListener('keyup', function () {
    var number = parseInt(inputEl.value);
    var message = '';
    var disable = true;
    if (isNaN(number)) {
        message = 'not  a number';
    }
    else if (number % 2 === 0) {
        message = number + ' is even';
        disable = false;
    }
    else {
        message = number + ' is odd';
    }
    messageEl.innerText = message;
    submitButton.disabled = disable;
});
//# sourceMappingURL=numberchecker.js.map