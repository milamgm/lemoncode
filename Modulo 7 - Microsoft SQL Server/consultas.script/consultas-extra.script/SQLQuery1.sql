SELECT T.Name AS TrackName,
       COUNT(PT.TrackId) AS NumberOfPlaylists
FROM Track T
JOIN PlaylistTrack PT ON T.TrackId = PT.TrackId
GROUP BY T.TrackId, T.Name
ORDER BY NumberOfPlaylists DESC;
