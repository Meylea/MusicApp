using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMusic.Data;
using MvcMusic.Models;

namespace MvcMusic
{
    [Route("api/Musics")]
    [ApiController]
    public class MusicsApiController : ControllerBase
    {
        private readonly MvcMusicContext _context;

        public MusicsApiController(MvcMusicContext context)
        {
            _context = context;
        }

        // GET: api/Musics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicDTO>>> GetMusic()
        {
            return await _context.Music
                .Where(x => x.Validated == true)
                .Select(x => MusicToDTO(x))
                .ToListAsync();
        }

        // GET: api/Musics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicDTO>> GetMusic(int id)
        {
            var music = await _context.Music.FindAsync(id);

            if (music == null)
            {
                return NotFound();
            }

            return MusicToDTO(music);
        }

        // PUT: api/Musics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusic(int id, MusicDTO musicDTO)
        {
            if (id != musicDTO.Id)
            {
                return BadRequest();
            }

            var music = await _context.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }

            music.Title = musicDTO.Title;
            music.Artist = musicDTO.Artist;
            music.ReleaseDate = musicDTO.ReleaseDate;
            music.Genre = musicDTO.Genre;
            music.Price = musicDTO.Price;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Musics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Music>> PostMusic(MusicDTO musicDTO)
        {
            var music = new Music
            {
                Title = musicDTO.Title,
                Artist = musicDTO.Artist,
                ReleaseDate = musicDTO.ReleaseDate,
                Genre = musicDTO.Genre,
                Price = musicDTO.Price
            };

            _context.Music.Add(music);
            await _context.SaveChangesAsync();

            return CreatedAtAction((nameof(GetMusic)), new { id = music.Id }, MusicToDTO(music));
        }

        // DELETE: api/Musics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var music = await _context.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }

            _context.Music.Remove(music);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicExists(int id)
        {
            return _context.Music.Any(e => e.Id == id);
        }

        private static MusicDTO MusicToDTO(Music music) => new MusicDTO
        {
            Id = music.Id,
            Title = music.Title,
            Artist = music.Artist,
            ReleaseDate = music.ReleaseDate,
            Genre = music.Genre,
            Price = music.Price
        };
    }
}
