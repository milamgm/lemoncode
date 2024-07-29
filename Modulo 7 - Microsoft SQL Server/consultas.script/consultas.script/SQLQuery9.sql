SELECT T.Name AS TrackName
FROM Track T
JOIN PlaylistTrack PT ON T.TrackId = PT.TrackId
JOIN Playlist P ON PT.PlaylistId = P.PlaylistId
WHERE P.Name = 'Heavy Metal Classic';
