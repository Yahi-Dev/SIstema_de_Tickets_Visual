  var passwordInput = document.getElementById('passwordinicio');
  var showPasswordButton = document.getElementById('show-password');

  showPasswordButton.addEventListener('click', function() {
    if (passwordInput.type === 'password') {
      passwordInput.type = 'text';
    } else {
      passwordInput.type = 'password';
    }
  });