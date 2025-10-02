import {useState, useEffect} from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import {callBackend} from "./lib/api.js";

function App() {
    const [count, setCount] = useState(0)
    const [data, setData] = useState([])
    useEffect(() => {
        let respData = callBackend("items")
        respData.then((d) => {
            if (d !== null && d !== undefined) {
                setData(d ?? [])
            }
        })
    }, []);
    
    return (
        <>
            <div>
                <a href="https://vite.dev" target="_blank">
                    <img src={viteLogo} className="logo" alt="Vite logo"/>
                </a>
                <a href="https://react.dev" target="_blank">
                    <img src={reactLogo} className="logo react" alt="React logo"/>
                </a>
            </div>
            <h1>Vite + React</h1>
            <div className="card">
                <button onClick={() => setCount((count) => count + 1)}>
                    count is {count}
                </button>
                <p>
                    Edit <code>src/App.jsx</code> and save to test HMR
                </p>
            </div>
            
            <div>
                {data.map((item, i) => {
                    return <p key={"item"+ `-${i}`}>Item: {item}</p>
                })}
            </div>
            
            <p className="read-the-docs">
                Click on the Vite and React logos to learn more
            </p>
        </>
    )
}

export default App
