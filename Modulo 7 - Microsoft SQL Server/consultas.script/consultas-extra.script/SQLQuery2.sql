SELECT T.Name AS TrackName,
       COUNT(IL.TrackId) AS NumberOfPurchases
FROM Track T
JOIN InvoiceLine IL ON T.TrackId = IL.TrackId
GROUP BY T.TrackId, T.Name
ORDER BY NumberOfPurchases DESC;
