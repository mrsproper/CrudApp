const inputEl = document.getElementById('number-check') as HTMLInputElement;
const messageEl = document.getElementById('number-check-message');
const submitButton = document.querySelector('form input[type="submit"]') as HTMLInputElement;

inputEl.addEventListener('keyup', function () {
    const number = parseInt(inputEl.value);
    let message = '';
    let disable = true;
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