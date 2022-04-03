function companyUsers(input) {

    let companies = {};

    for (let line of input) {
        let [company, number] = line.split(' -> ');

        if (!companies.hasOwnProperty(company)) {
            companies[company] = [];
        }
        if (!companies[company].includes(number)) {
            companies[company].push(number);
        }
    }
    let sortedCompanies = Object.keys(companies);
    sortedCompanies.sort((a, b) => a.localeCompare(b));

    for (let company of sortedCompanies) {
        console.log(company);

        for (let empl of companies[company]) {
            console.log(`-- ${empl}`);
        }
    }
}
companyUsers([
    'SoftUni -> AA12345',
    'SoftUni -> BB12345',
    'Microsoft -> CC12345',
    'HP -> BB12345'
]);

companyUsers([
    'SoftUni -> AA12345',
    'SoftUni -> CC12344',
    'Lenovo -> XX23456',
    'SoftUni -> AA12345',
    'Movement -> DD11111'
]);