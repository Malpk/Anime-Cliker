mergeInto(LibraryManager.library, { 

  ShowReclama: function () {
   ysdk.adv.showRewardedVideo({
    callbacks: {
      onOpen: () => {
        console.log('Video ad open. ---- PouseMusic');
        MyGameInstance.SendMessage('AudioManager', 'PouseMusic'); 
      },
      onRewarded: () => { 
        console.log('Rewarded!');
        
      },
      onClose: () => {
        console.log('Video ad closed. ---- PlayingMusic');
        MyGameInstance.SendMessage('AudioManager', 'PlayingMusic');
      }, 
      onError: (e) => {
        console.log('Error while open video ad:', e);
      }
    }
  })
 },  

});