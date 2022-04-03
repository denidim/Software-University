function towns(townInfo) {

    for (let info of townInfo) {
        
        let [town, latitude, longitude] = info.split(' | ');

        let townData = {
            town: town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2)
        };

        console.log(townData);
    }
}
towns([
    'Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625'
]);
