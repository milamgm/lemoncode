SELECT A.Name AS ArtistName
FROM Artist A
LEFT JOIN Album AL ON A.ArtistId = AL.ArtistId
WHERE AL.ArtistId IS NULL;


SELECT A.Name AS ArtistName,
       COUNT(AL.AlbumId) AS NumberOfAlbums
FROM Artist A
LEFT JOIN Album AL ON A.ArtistId = AL.ArtistId
GROUP BY A.ArtistId, A.Name
HAVING COUNT(AL.AlbumId) = 0;
