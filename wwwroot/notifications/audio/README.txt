Audio Notifications Folder

This folder contains audio files for notifications:
- notification.mp3 (default notification sound)
- success.mp3 (success notification sound)
- warning.mp3 (warning notification sound)
- error.mp3 (error notification sound)

To use audio notifications:
1. Replace the placeholder files with actual MP3 audio files
2. Include the notifications.js file in your pages
3. Call window.audioNotifications.notify('type') to play notifications

Example usage in JavaScript:
window.audioNotifications.notify('success');
window.audioNotifications.notify('warning');
window.audioNotifications.notify('error');