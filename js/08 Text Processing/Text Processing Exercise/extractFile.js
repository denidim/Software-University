function solve(str) {
    let index = str.lastIndexOf('\\');
    let fileName = str.substring(index + 1).split('.');
    let extension = fileName.pop();
    let template = fileName.join('.');

    console.log(`File name: ${template}`);
    console.log(`File extension: ${extension}`);
}
solve('C:\\Internal\\training-internal\\Template.pptx');
solve('C:\\Projects\\Data-Structures\\LinkedList.cs');