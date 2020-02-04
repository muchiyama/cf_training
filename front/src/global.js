

function decodeBytesFromBase64(b64) {
    return atob(b64.replace(/^.*,/, ''));
}

function convertbytesToBinary(sb) {
    let b = new Uint8Array(sb.length);
    for (var i = 0;i < sb.length;i++) {
        b[i] = sb.charCodeAt(i);
    }
    return b;
}

function createBinaryFromBase64 (c) {
    let b = convertbytesToBinary(decodeBytesFromBase64(c));
    let bb = new Blob([b.buffer], {
        type: 'audio/mp3'
    });
    return window.URL.createObjectURL(bb);
}