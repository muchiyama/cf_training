

function decodeBytesFromBase64(base64) {
    return atob(base64.replace(/^.*,/, ''));
}

function convertbytesToBinary(bytes) {
    var buffer = new Uint8Array(bytes.length);
    for (var i = 0;i < bytes.length;i++) {
        buffer[i] = bytes.charCodeAt(i);
    }
    return buffer;
}

function createBinaryFromBase64 (c) {
    var buffer = convertbytesToBinary(decodeBytesFromBase64(c));

    var blob = new Blob([buffer.buffer], {
        type: 'audio/mp3'
    });

    return window.URL.createObjectURL(blob);
}