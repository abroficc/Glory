// ===============================
// 🔔 Simple Audio Notifications + News Ticker
// ===============================

// Global flag to track if audio has been played
let audioHasPlayed = false;

// Simple function to play audio with multiple fallbacks
function playNotificationSound() {
    return new Promise((resolve) => {
        // If audio already played, don't play again
        if (audioHasPlayed) {
            resolve(true);
            return;
        }
        
        try {
            console.log('[Notifications] Attempting to play sound');
            const audio = new Audio('/notifications/audio/new-notification-017-352293.mp3');
            audio.volume = 0.8;
            
            // Try different approaches to play audio
            // 1. Normal play
            const playPromise = audio.play();
            if (playPromise !== undefined) {
                playPromise.then(() => {
                    console.log('[Notifications] Sound played successfully');
                    audioHasPlayed = true;
                    resolve(true);
                }).catch(error => {
                    console.warn('[Notifications] Audio play failed:', error);
                    // 2. Try with muted audio first (more likely to autoplay)
                    tryMutedPlayback().then(result => {
                        if (result) {
                            audioHasPlayed = true;
                            resolve(true);
                        } else {
                            // 3. Set up fallback for user interaction
                            setupFallbackAudio();
                            resolve(false);
                        }
                    });
                });
            } else {
                // For older browsers
                audioHasPlayed = true;
                setTimeout(() => resolve(true), 100);
            }
        } catch (error) {
            console.error('[Notifications] Audio error:', error);
            // Set up fallback for user interaction
            setupFallbackAudio();
            resolve(false);
        }
    });
}

// Try to play audio muted first (higher chance of autoplay)
function tryMutedPlayback() {
    return new Promise((resolve) => {
        try {
            console.log('[Notifications] Trying muted playback');
            const audio = new Audio('/notifications/audio/new-notification-017-352293.mp3');
            audio.volume = 0;
            audio.muted = true;
            
            const playPromise = audio.play();
            if (playPromise !== undefined) {
                playPromise.then(() => {
                    console.log('[Notifications] Muted sound played successfully');
                    // Now try to unmute and play again
                    setTimeout(() => {
                        audio.volume = 0.8;
                        audio.muted = false;
                        audio.play().then(() => {
                            console.log('[Notifications] Unmuted sound played successfully');
                            audioHasPlayed = true;
                            resolve(true);
                        }).catch(() => {
                            console.log('[Notifications] Could not unmute, keeping muted playback');
                            audioHasPlayed = true;
                            resolve(true);
                        });
                    }, 100);
                }).catch(() => {
                    console.log('[Notifications] Muted playback failed');
                    resolve(false);
                });
            } else {
                resolve(false);
            }
        } catch (error) {
            console.error('[Notifications] Muted playback error:', error);
            resolve(false);
        }
    });
}

// Setup fallback for user interaction
function setupFallbackAudio() {
    console.log('[Notifications] Setting up fallback audio');
    
    // Play sound on first user interaction
    const playOnInteraction = () => {
        // If audio already played, don't play again
        if (audioHasPlayed) {
            document.removeEventListener('click', playOnInteraction);
            document.removeEventListener('touchstart', playOnInteraction);
            document.removeEventListener('keydown', playOnInteraction);
            return;
        }
        
        console.log('[Notifications] User interacted, playing sound');
        const audio = new Audio('/notifications/audio/new-notification-017-352293.mp3');
        audio.volume = 0.8;
        audio.play().then(() => {
            audioHasPlayed = true;
            console.log('[Notifications] Fallback sound played successfully');
        }).catch(e => console.warn('[Notifications] Fallback audio failed:', e));
        
        // Remove event listeners
        document.removeEventListener('click', playOnInteraction);
        document.removeEventListener('touchstart', playOnInteraction);
        document.removeEventListener('keydown', playOnInteraction);
    };
    
    // Add event listeners
    document.addEventListener('click', playOnInteraction);
    document.addEventListener('touchstart', playOnInteraction);
    document.addEventListener('keydown', playOnInteraction);
}

// Show news ticker immediately
function showNewsTicker() {
    console.log('[Notifications] Showing news ticker');
    
    const container = document.querySelector('.news-ticker-container');
    const header = document.querySelector('.ticker-header');
    const content = document.querySelector('.ticker-content');
    const items = document.querySelector('.ticker-items');
    
    if (!container || !header || !content || !items) {
        console.warn('[Notifications] News ticker elements not found');
        return;
    }
    
    // Show all elements immediately
    container.style.display = 'block';
    header.style.display = 'flex';
    content.style.display = 'flex';
    items.style.animationPlayState = 'running';
    
    // Add fade-in animation
    container.classList.add('fade-in');
    header.classList.add('fade-in');
    content.classList.add('fade-in');
}

// Initialize when DOM is loaded
document.addEventListener('DOMContentLoaded', async function() {
    console.log('[Notifications] DOM loaded, initializing');
    
    // Play sound and then show news ticker
    const soundPlayed = await playNotificationSound();
    console.log('[Notifications] Sound play result:', soundPlayed);
    
    // Show news ticker immediately after sound attempt
    showNewsTicker();
});

// Also try to play sound on visibility change (tab focus)
document.addEventListener('visibilitychange', function() {
    if (document.visibilityState === 'visible' && !audioHasPlayed) {
        playNotificationSound();
    }
});

// Try to play sound immediately when script loads (before DOM)
playNotificationSound();