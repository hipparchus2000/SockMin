$(document).ready(function () {
    
         var username = prompt('Please enter a username:');
      
         var uri = 'ws://localhost:58949/SockMin/ws?username=' + username;
         websocket = new WebSocket(uri);
      
         websocket.onopen = function () {
                 $('#messages').prepend('<div>Connected.</div>');
          
                 $('#chatform').submit(function (event) {
                         websocket.send($('#inputbox').val());
                         $('#inputbox').val('');
                         event.preventDefault();
                     });
             };
      
         websocket.onerror = function (event) {
                 $('#messages').prepend('<div>ERROR</div>');
             };
      
         websocket.onmessage = function (event) {
                 $('#messages').prepend('<div>' + event.data + '</div>');
             };
     });