


'use strict';

var forth = require('../lib'),
    expect = require('chai').expect;

function run (str, ds, rs, done) {
    var f = forth();
    f.interpret(str, function () {
        expect([f.DS, f.RS]).to.deep.equal([ds, rs]);
        done();
    })
}

describe('#basic', function () {
    it('#words', function () {
        forth.words();
    });
    it('#see', function () {
        forth.see(forth.see);
    });
    it('#stack', function () {
        run('0 0 and', [0], []);
        run('0 1 and', [0], []);
        run('1 0 and', [0], []);
        run('1 1 and', [1], []);

        run('0 invert 1 and', [1], []);
        run('1 invert 1 and', [0], []);

        run('1 2*', [2], []);
        run('4000 2/', [2000], []);
        run('1 15 lshift', [32768], []);
        run('4 2 rshift', [1], []);
        run('0 0=', [true], []);
        run('-1 0=', [false], []);

        run('-5 9 +', [4], []);
        run('7 3 -', [4], []);
        run('dup', [4, 4], []);
        run('drop drop', [], []);
    });
    it('#stream', function () {
        forth.quit();
        forth.inputStream.end('123 456 - ');
        expect(forth.DS).to.deep.equal([-333]);
    });
});
