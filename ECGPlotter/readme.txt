
SQLITE Statements
------------------

选择记录：

SELECT Id,
       Fullpath,
       Status
  FROM Labels
  WHERE Status IN (0,1,2,3);

修改记录：
update labels set status=9 where id in (7,9,8);

创建表结构：
CREATE TABLE Labels (
    Id         INTEGER CONSTRAINT PK_Labels PRIMARY KEY AUTOINCREMENT,
    Fullpath   TEXT    UNIQUE
                       NOT NULL,
    HeaderInfo TEXT    NOT NULL,
    LeadsInfo  TEXT    NOT NULL,
    LabelList  TEXT    NOT NULL,
    CreateUser TEXT,
    CreateDate TEXT,
    UpdateUser TEXT,
    UpdateDate TEXT,
    Status     INTEGER DEFAULT (0),
    Blob       BLOB
);

合并两个sqlite 文件：

第一步：First attach db2 
第二步：

CREATE TEMPORARY TABLE tmp AS SELECT * FROM db2.mytable;
UPDATE tmp SET id = NULL;
INSERT  INTO mytable SELECT * FROM tmp;
DROP TABLE tmp;

DeepSeek 推荐：how do I combine multiple sqlite database with same structure?

回答中的方法2似乎更好，但主键会有问题：

1，Export data from the secondary database:
sqlite3 secondary.db .dump > secondary_dump.sql
2，Import the data into the primary database:
sqlite3 primary.db ".read secondary_dump.sql"
3，Repeat for other databases:
Repeat steps 1–2 for each additional database.

Python 代码可以试试：
import sqlite3

# Paths to your databases
primary_db = 'primary.db'
secondary_dbs = ['secondary1.db', 'secondary2.db']

# Connect to the primary database
conn_primary = sqlite3.connect(primary_db)
cursor_primary = conn_primary.cursor()

for db in secondary_dbs:
    # Connect to the secondary database
    conn_secondary = sqlite3.connect(db)
    cursor_secondary = conn_secondary.cursor()

    # Get the list of tables
    cursor_secondary.execute("SELECT name FROM sqlite_master WHERE type='table';")
    tables = cursor_secondary.fetchall()

    for table in tables:
        table_name = table[0]
        # Copy data from the secondary database to the primary database
        cursor_secondary.execute(f"SELECT * FROM {table_name};")
        rows = cursor_secondary.fetchall()
        cursor_primary.executemany(f"INSERT INTO {table_name} VALUES ({','.join(['?']*len(rows[0]))};", rows)

    # Commit changes and close the secondary database connection
    conn_primary.commit()
    conn_secondary.close()

# Close the primary database connection
conn_primary.close()


CurColorSchema:

"WHITE"
"BLUE"
"GRAY"
"LIGHT_BLUE"
"BLACK"
"RED"
"DARK_GREEN"

CurExample:

"NORMAL"
"NORMAL_AUTO"
"STACKED"
"VERTICAL_ALIGNED"
"VERTICAL_ALIGNED_AUTO"
"TILED_VERTICAL"
"TILED_VERTICAL_AUTO"
"TILED_HORIZONTAL"
"TILED_HORIZONTAL_AUTO"

What P Waves Look Like on Your Watch ECG
https://www.qaly.co/post/what-p-waves-look-like-in-your-watch-ecg

Comparison of FFT Implementations for .NET
https://www.codeproject.com/Articles/1095473/Comparison-of-FFT-Implementations-for-NET

SharpFFTW
https://github.com/wo80/SharpFFTW

NWaves
https://github.com/ar1st0crat/NWaves

Accord.NET
https://github.com/Azure/Accord-NET

https://github.com/schueco/accord-net-framework .net6.0 & .net8.0

Conquering the ECG
https://www.ncbi.nlm.nih.gov/books/NBK2214/

Discrete Haar Wavelet Transformation
https://www.codeproject.com/Articles/683663/Discrete-Haar-Wavelet-Transformation