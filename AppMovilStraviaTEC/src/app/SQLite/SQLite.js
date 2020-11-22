const sqlite3 = require('sqlite3').verbose();

// open the database connection
let db = new sqlite3.Database('C:/Users/PC34/Desktop/TEC/Vl Semestre/Bases de Datos/PROYECTO1/StraviaTec/AppMovilStraviaTEC/src/app/SQLite/ejemplo.db');

let languages = ['C++', 'Python', 'Java', 'C#', 'Go'];

db.serialize(function() {

  // Crear tabla personas
  db.run("CREATE TABLE IF NOT EXISTS langs (name TEXTT)");
});

// construct the insert statement with multiple placeholders
// based on the number of rows
let placeholders = languages.map((language) => '(?)').join(',');
let sql = 'INSERT INTO langs(name) VALUES ' + placeholders;

// output the INSERT statement
console.log(sql);

db.run(sql, languages, function(err) {
  if (err) {
    return console.error(err.message);
  }
  //console.log(Rows inserted ${this.changes});
});

// close the database connection
db.close();