
const baseUrl =  import.meta.env.VITE_BACKEND_URL ?? ""
export async function callBackend(endpoint){
    console.log(`callBackend: ep: ${endpoint} url: ${baseUrl}`)
    const resp = await fetch(`${baseUrl}/api/${endpoint}`)
    if (!resp.ok) {
        throw new Error(`HTTP req Status: ${resp.status}`);
    }
    return resp.json()
}