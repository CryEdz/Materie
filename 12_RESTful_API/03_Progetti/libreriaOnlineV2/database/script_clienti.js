export const CREATE_CLIENTI_TABLE = `CREATE TABLE IF NOT EXISTS clienti (
                                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        nome TEXT NOT NULL,
                                        cognome TEXT NOT NULL,
                                        email TEXT NOT NULL UNIQUE,
                                        telefono TEXT
                                    )`;
export const SELECT_ALL = "SELECT * FROM clienti";

export const SELECT_BY_ID = "SELECT * FROM clienti WHERE id = ?";

export const SELECT_BY_NOME = "SELECT * FROM clienti WHERE LOWER(nome) LIKE '%' || LOWER(?) || '%'";

export const SELECT_BY_COGNOME = "SELECT * FROM clienti WHERE LOWER(cognome) LIKE '%' || LOWER(?) || '%'";

export const INSERT_CLIENTE = "INSERT INTO clienti (nome, cognome, email, telefono) VALUES (?, ?, ?, ?)";

export const UPDATE_CLIENTE = "UPDATE clienti SET nome = ?, cognome = ?, email = ?, telefono = ? WHERE id = ?";

export const DELETE_CLIENTE = "DELETE FROM clienti WHERE id = ?";