function robotSpeak(message) {
    const robotContainer = document.getElementById('robot-container')
    if (message != "Empty") {

        document.getElementById('robot-text').innerText = message;

        document.getElementById('robot-image').src = "\Images\Robot.gif";

        var duration = Math.max(message.length * 200, 1000); // Adjust duration as needed)

        setTimeout(() => {
            document.getElementById('robot-image').src = "\Images\Robot.gif";
            document.getElementById('robot-text').innerText = "";
            robotContainer.style.display = "none";
        }, duration); // Adjust duration as needed
    }
    else {
        robotContainer.style.display = "none";
    }
}

function fetchRobotMessage() {
    fetch('/Robot/GetRobotMessage')
        .then(response => response.json())
        .then(data => {
            robotSpeak(data.message);
        });
}

// Trigger the robot when the page loads
document.addEventListener('DOMContentLoaded', fetchRobotMessage);
