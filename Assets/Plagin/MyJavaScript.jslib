mergeInto(LibraryManager.library, { 

  ShowReclama: function () {
   ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
         MyGameInstance.SendMessage('AudioManager', 'PlayingMusic');
        },
        onError: function(error) {
          // some action on error
        }
    }
})
 },   
});