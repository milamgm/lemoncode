SELECT T.Name, T.Milliseconds
FROM Track T
WHERE T.Milliseconds > 4 * 60 * 1000;
