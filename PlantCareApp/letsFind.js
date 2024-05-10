document.getElementById("home-btn").addEventListener("click", function() {
    window.location.href = "index.html";
});

const searchButton = document.querySelector('.search-box button');
const searchInput = document.querySelector('.search-box input');
const errorElement = document.querySelector('.not-found');
const container = document.querySelector('.container');
const names = document.querySelector('.names');
const care = document.querySelector('.care');
const foto = document.querySelector('.foto');

searchButton.addEventListener('click', () => {
    const APIKey = 'k6RjKNhc0oDXRImHgxTp724WIRcqinWDRhx9V65GPjkk4Ym5YW';
    const plantName = searchInput.value.trim(); // Kullanıcının girdiği bitki ismi

    // API isteği
    fetch(`https://plant.id/api/v3/kb/plants/name_search?q=${plantName}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Api-Key': APIKey
        }
    })
    .then(response => response.json())
    .then(json => {
        console.log(json); // JSON yanıtını konsola yazdırma

        if (json.error && json.error.code === 1006) {
            // Hata durumunda
            container.style.height = '85%';
            document.querySelectorAll('.names, .care, .foto').forEach(element => {
                element.style.visibility = 'hidden';
            });
            document.querySelector('.not-found').style.visibility = 'visible'; 
        } else if (!json.entities || json.entities.length === 0 || !json.entities[0].access_token) {
            // Eğer entities dizisi boşsa veya accessKey tanımsızsa, hata durumu işle
            container.style.height = '85%';
            document.querySelectorAll('.names, .care, .foto').forEach(element => {
                element.style.visibility = 'hidden';
            });
            document.querySelector('.not-found').style.visibility = 'visible'; 
        }  else {
            // Hata olmadığında
            container.style.height = '85%';
            document.querySelectorAll('.names, .care, .foto').forEach(element => {
                element.style.visibility = 'visible';
            });
            document.querySelector('.not-found').style.visibility = 'hidden';

            // Eşleşen accessKey verileri kullanarak ikinci API isteğini yapma
            const accessKey = json.entities[0].access_token;

            fetch(`https://plant.id/api/v3/kb/plants/${accessKey}?details=common_names,url,description,taxonomy,rank,gbif_id,inaturalist_id,image,synonyms,edible_parts,watering,propagation_methods`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Api-Key': APIKey
                }
            })
            .then(response => response.json())
            .then(data => {
                if (data.error && data.error.code === 1006) {
                    // Hata durumunda
                    container.style.height = '85%';
                    document.querySelectorAll('.names, .care, .foto').forEach(element => {
                        element.style.visibility = 'hidden';
                    });
                    document.querySelector('.not-found').style.visibility = 'visible'; 
                } else {
                    // Verileri eşleşen alanlara yerleştirme
                   // Common Names'e yerleştirme
                    document.querySelector('.common-names .description').textContent = data.common_names.join(', ');

                    // Describing'e yerleştirme
                    document.querySelector('.value .description').textContent = data.description.value;

                    // Edible Parts'e yerleştirme
                    document.querySelector('.edible_parts .description').textContent = data.edible_parts.join(', ');

                    // Watering'e yerleştirme
                    document.querySelector('.watering .description').textContent = `Min: ${data.watering.min}, Max: ${data.watering.max}`;

                    // Propagation Methods'e yerleştirme
                    document.querySelector('.propagation_methods .description').textContent = data.propagation_methods.join(', ');

                    // Fotoğraf src'sine yerleştirme
                    document.getElementById('apiImage1').src = data.image.value;
                }
            });
        }
    });
});
