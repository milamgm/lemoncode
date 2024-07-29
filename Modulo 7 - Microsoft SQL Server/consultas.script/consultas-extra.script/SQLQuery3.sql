SELECT A.Name AS ArtistName,
       COUNT(IL.TrackId) AS NumberOfPurchases
FROM Artist A
JOIN Album AL ON A.ArtistId = AL.ArtistId
JOIN Track T ON AL.AlbumId = T.AlbumId
JOIN InvoiceLine IL ON T.TrackId = IL.TrackId
GROUP BY A.ArtistId, A.Name
ORDER BY NumberOfPurchases DESC;
