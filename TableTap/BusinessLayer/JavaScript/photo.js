(function () {
    var video = document.getElementById('video'),
        canvas=document.getElementById('canvas'),
        context = canvas.getContext('2d'),
        photo = document.getElementById('photo'),
        vendorURL = window.URL || window.webkitURL;

    navigator.getMedia =    navigator.getUserMedia ||
                            navigator.webkitGetUserMedia ||
                            navigator.mozGetUserMedia ||
                            navigator.msGetUserMedia;

    navigator.getMedia({
        video: true,
        audio: false
    }, function (stream) {
        try {
            video.srcObject(stream);
            video.play();
        } catch (error) {
            video.src = vendorURL.createObjectURL(stream);
            video.play();
        }

    } , function (error) {
        //an error occurred
        //error.code
    });

    //document.getElementById('capture').addEventListener('click', function() {
    //    context.drawImage(video, 0, 0, 400, 300);
    //    photo.setAttribute("src", canvas.toDataURL('image/png'));
    //});


})();