//setting up the dependencies
const chai = require('chai');
const chaiHttp = require('chai-http');
const server = require('./server');
const expect = chai.expect;

chai.use(chaiHttp);

describe('books', () => {
    it('should be able to create new book' , (done) => {
        const book = {id:'1',title:'Test Book',author: 'Test Author'};
        chai.request(server)
        .post('/books')
        .send(book)
        .end((err,res) => {
            if(err){
                return done(err)
            }
            console.log("response: ",res.body)
            done();
        });
    })
})