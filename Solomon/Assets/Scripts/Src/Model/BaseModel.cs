using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Const;
using Util;

namespace Model {

    public class BaseModel {

        public string tableName;

        public List<Dictionary<string, string>> fetchAll (Dictionary<string, string> where = null) {
            List<Dictionary<string, string>> _Db = import ();
            if (where == null) {
                return _Db;
            }
            List<Dictionary<string, string>> _list = new List<Dictionary<string, string>> (_Db);
            List<Dictionary<string, string>> _result = new List<Dictionary<string, string>> ();
            foreach (KeyValuePair<string, string> kvp in where) {
                _result.Clear ();
                string _column = kvp.Key;
                string _value = kvp.Value;
                foreach (Dictionary<string, string> row in _list) {
                    if (row[_column] == _value) {
                        _result.Add (row);
                    }
                }
                _list = new List<Dictionary<string, string>> (_result);
            }
            return _result;
        }

        public Dictionary<string, string> fetchRow (Dictionary<string, string> where) {
            List<Dictionary<string, string>> _Db = import ();
            List<Dictionary<string, string>> _list = new List<Dictionary<string, string>> (_Db);
            List<Dictionary<string, string>> _result = new List<Dictionary<string, string>> ();
            foreach (KeyValuePair<string, string> kvp in where) {
                _result.Clear ();
                string _column = kvp.Key;
                string _value = kvp.Value;
                foreach (Dictionary<string, string> row in _list) {
                    if (row[_column] == _value) {
                        _result.Add (row);
                    }
                }
                _list = new List<Dictionary<string, string>> (_result);
            }
            return _result[0];
        }

        public void insert (List<Dictionary<string, string>> rows) {
            string[] _columns = getColumn ();
            foreach (Dictionary<string, string> row in rows) {
                if (row.Count != _columns.Length) {
                    Log.err (Log.ERR_MISMATCH_COLUMNS_LENGTH);
                    return;
                }
                int i = 0;
                foreach (KeyValuePair<string, string> kvp in row) {
                    if (kvp.Key != _columns[i]) {
                        Log.err (Log.ERR_MISMATCH_COLUMNS_DETAIL);
                        return;
                    }
                    i++;
                }
            }
            export (rows, true);
        }

        public void update (Dictionary<string, string> where, Dictionary<string, string> param) {
            List<Dictionary<string, string>> _db = import ();
            List<Dictionary<string, string>> _list = new List<Dictionary<string, string>> (_db);
            List<Dictionary<string, string>> _fetch = new List<Dictionary<string, string>> ();
            List<Dictionary<string, string>> _updateDb = new List<Dictionary<string, string>> ();
            foreach (KeyValuePair<string, string> kvp in where) {
                _fetch.Clear ();
                foreach (Dictionary<string, string> row in _list) {
                    if (row[kvp.Key] == kvp.Value) {
                        _fetch.Add (row);
                    }
                }
                _list = new List<Dictionary<string, string>> (_fetch);
            }
            foreach (KeyValuePair<string, string> kvp in param) {
                foreach (Dictionary<string, string> row in _fetch) {
                    row[kvp.Key] = kvp.Value;
                }
            }
            foreach (Dictionary<string, string> row in _db) {
                var f = false;
                var insertRow = new Dictionary<string, string> ();
                foreach (Dictionary<string, string> updateRow in _fetch) {
                    foreach (KeyValuePair<string, string> kvp in updateRow) {
                        if (row[kvp.Key] == kvp.Value) {
                            insertRow = updateRow;
                            f = true;
                            break;
                        } else {
                            insertRow = row;
                            break;
                        }
                    }
                    if (f) {
                        break;
                    }
                }
                _updateDb.Add (insertRow);
            }
            export (_updateDb);
        }

        public void delete (Dictionary<string, string> where) {
            List<Dictionary<string, string>> _db = import ();
            List<Dictionary<string, string>> _list = new List<Dictionary<string, string>> (_db);
            List<Dictionary<string, string>> _fetch = new List<Dictionary<string, string>> ();
            List<Dictionary<string, string>> _deleteDb = new List<Dictionary<string, string>> ();
            foreach (KeyValuePair<string, string> kvp in where) {
                _fetch.Clear ();
                foreach (Dictionary<string, string> row in _list) {
                    if (row[kvp.Key] == kvp.Value) {
                        _fetch.Add (row);
                    }
                }
                _list = new List<Dictionary<string, string>> (_fetch);
            }
            foreach (Dictionary<string, string> row in _db) {
                var f = false;
                var insertRow = new Dictionary<string, string> ();
                foreach (Dictionary<string, string> deleteRow in _fetch) {
                    foreach (KeyValuePair<string, string> kvp in deleteRow) {
                        if (row[kvp.Key] == kvp.Value) {
                            f = true;
                            break;
                        } else {
                            insertRow = row;
                            break;
                        }
                    }
                    if (f) {
                        break;
                    }
                }
                _deleteDb.Add (insertRow);
            }
            export (_deleteDb);
        }

        public List<Dictionary<string, string>> import () {
            List<Dictionary<string, string>> _list = new List<Dictionary<string, string>> ();
            try {
                StreamReader _sr = new StreamReader (Const.Path.DB_DIRECTRY_PATH + this.tableName + ".csv");
                string _header = _sr.ReadLine ();
                string[] _columns = _header.Split (',');
                while (!_sr.EndOfStream) {
                    string _line = _sr.ReadLine ();
                    string[] _values = _line.Split (',');
                    Dictionary<string, string> _dic = new Dictionary<string, string> ();
                    for (int i = 0; i < _values.Length; i++) {
                        _dic.Add (_columns[i], _values[i]);
                    }
                    _list.Add (_dic);
                }
            } catch (System.Exception e) {
                Log.info (e.Message);
            }
            return _list;
        }

        public string[] getColumn () {
            string[] _columns = { };
            try {
                StreamReader _sr = new StreamReader (Const.Path.DB_DIRECTRY_PATH + this.tableName + ".csv");
                string _header = _sr.ReadLine ();
                _columns = _header.Split (',');
            } catch (System.Exception e) {
                Log.info (e.Message);
            }
            return _columns;
        }

        public void export (List<Dictionary<string, string>> db, bool append = false) {
            //StreamReader _sr = new StreamReader (this.tableName + ".csv");
            StreamWriter _sw = new StreamWriter ("export.csv", append);
            if (!append) {
                List<string> head = new List<string> ();
                foreach (KeyValuePair<string, string> kvp in db[0]) {
                    head.Add (kvp.Key);
                }
                _sw.WriteLine (string.Join (",", head.ToArray ()));
            }
            foreach (Dictionary<string, string> row in db) {
                string[] vals = new string[row.Values.Count];
                row.Values.CopyTo (vals, 0);
                _sw.WriteLine (string.Join (",", vals));
            }
            _sw.Close ();
        }
    }
}