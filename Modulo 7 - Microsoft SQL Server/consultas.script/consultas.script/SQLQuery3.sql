SELECT T.Name, T.Milliseconds
FROM Track T
WHERE T.Milliseconds BETWEEN 2 * 60 * 1000 AND 3 * 60 * 1000;
