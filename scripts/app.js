const app = async () => {
    const url = "https://api.themoviedb.org/3/movie/popular"
    const token = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJjZWUwYzcyY2I2ZGVhMjM1NDUyMTQxMzBjMGQwYTM2NiIsInN1YiI6IjY0NjA5NGM5OGM0NGI5MDExOWNhOGRjZCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.1mmhAmSLn8E5IYdFHvTeVva7y4a2gew75i7muOouoHE"
    const response = await fetch(url, {
        method: "GET",
        headers: {
            Authentication: `Bearer ${token}`
        }
    })
        .then(res => res.json())
        .then((data) => console.log(data))
}

app()