//setting up the dependencies
const chai = require('chai');
const chaiHttp = require('chai-http');
const server = require('./server');
const expect = chai.expect;

chai.use(chaiHttp);

describe('Books API', () => {
    it('should be able to create new book' , (done) => {
        const book = {id:'1',title:'Test Book',author: 'Test Author'};
        chai.request(server)
        .post('/books')
        .send(book)
        .end((err,res) => {
            if(err){
                return done(err)
            }
            expect(res.statusCode, "Status code").to.be.equal(201);
            expect(res.body, "ResponseBody").to.be.a('object');
            expect(res.body, "ResponseBody").to.have.property('id');
            expect(res.body.id, "BookId property").to.be.equal(book.id);
            expect(res.body.title, "BookTitle property").to.be.equal(book.title);
            expect(res.body.author, "BookAuthor property").to.be.equal(book.author);
            console.log("response: ",res.body);
            done();
        });
    })
})