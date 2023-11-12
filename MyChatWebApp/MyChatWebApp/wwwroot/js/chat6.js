// chat-widget.js

class ChatWidget {
    constructor() {
        // Create the chat widget container
        const chatWidgetContainer = document.createElement('div');
        chatWidgetContainer.id = 'chat-widget';

        // Add your chat widget's HTML and styling here
        chatWidgetContainer.innerHTML = `
      <div id="chat-messages"></div>
      <input type="text" id="message-input" placeholder="Type a message...">
      <button id="send-button">Send</button>
    `;

        // Add any additional JavaScript logic for the chat widget here

        // Append the chat widget container to the host website's body
        document.body.appendChild(chatWidgetContainer);
    }
}
