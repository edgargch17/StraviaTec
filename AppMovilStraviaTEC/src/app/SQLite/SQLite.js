const sqlite3 = require('sqlite3').verbose();
sqlite3 = require('sqlite3').verbose();
   
   /* // open database in memory
let db = new sqlite3.Database(':memory:', (err) => {
    if (err) {
      return console.error(err.message);
    }
    console.log('Connected to the in-memory SQlite database.');
  });
  
  // close the database connection
  db.close((err) => {
    if (err) {
      return console.error(err.message);
    }
    console.log('Close the database connection.');
  });*/

  // open the database
let db = new sqlite3.Database('C:/Users/1001001164/Documents/UNIVERSIDAD/D1/Angular8Tutorial-master/api/loco.db', (err) => {
    if (err) {
      console.error(err.message);
    }
    console.log('Connected to the loco database.');
  });
  
  db.serialize(() => {
    db.each(`SELECT PlaylistId as id,
                    Name as name
             FROM playlists`, (err, row) => {
      if (err) {
        console.error(err.message);
      }
      console.log(row.id + "\t" + row.name);
    });
  });
  
  db.close((err) => {
    if (err) {
      console.error(err.message);
    }
    console.log('Close the database connection.');
  });


// open the database connection
//let db = new sqlite3.Database('C:/Users/PC34/Desktop/TEC/Vl Semestre/Bases de Datos/PROYECTO1/StraviaTec/AppMovilStraviaTEC/src/app/SQLite/ejemplo.db');

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


// open a database connection
let db = new sqlite3.Database('../api/delete.db', (err) => {
  if (err) {
    console.error(err.message);
  }
});

let id = 1;
// delete a row based on id
db.run(`DELETE FROM langs WHERE rowid=?`, id, function(err) {
  if (err) {
    return console.error(err.message);
  }
  console.log(`Row(s) deleted ${this.changes}`);
});

// close the database connection
db.close((err) => {
  if (err) {
    return console.error(err.message);
  }
});


// open the database
let db = new sqlite3.Database('C:/Users/1001001164/Documents/UNIVERSIDAD/D1/Angular8Tutorial-master/api/loco.db');

let sql = `SELECT DISTINCT Name name FROM playlists
           ORDER BY name`;

db.all(sql, [], (err, rows) => {
  if (err) {
    throw err;
  }
  rows.forEach((row) => {
    console.log(row.name);
  });
});

// close the database connection
db.close();