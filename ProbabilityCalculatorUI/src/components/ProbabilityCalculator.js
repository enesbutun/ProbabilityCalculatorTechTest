import React, { useState } from 'react';
import ProbabilityForm from './ProbabilityForm';
import ResultDisplay from './ResultDisplay';
import { calculateProbability } from '../services/probabilityService';
import '../styles/ProbabilityCalculator.css';

const ProbabilityCalculator = () => {
    const [result, setResult] = useState(null);
    const [error, setError] = useState(null);

    const handleFormSubmit = async (probabilityA, probabilityB, operation) => {
        try {
            const result = await calculateProbability(probabilityA, probabilityB, operation);
            setResult(result);
            setError(null);
        } catch (err) {
            setError(err.message);
            setResult(null);
        }
    };

    return (
        <div className="container">
            <h2>Probability Calculator</h2>
            <ProbabilityForm onSubmit={handleFormSubmit} />
            <ResultDisplay result={result} error={error} />
        </div>
    );
};

export default ProbabilityCalculator;



// import React, { useState } from 'react';
// import axios from 'axios';
// import './ProbabilityCalculator.css'; 

// const ProbabilityCalculator = () => {
//     const [probabilityA, setProbabilityA] = useState('');
//     const [probabilityB, setProbabilityB] = useState('');
//     const [operation, setOperation] = useState('CombinedWith');
//     const [result, setResult] = useState(null);
//     const [error, setError] = useState(null);

//     const handleSubmit = async (e) => {

//         e.preventDefault();

//         // Validation: Ensure probabilities are within range
//         if (probabilityA < 0 || probabilityA > 1 || probabilityB < 0 || probabilityB > 1) {
//             setError("Probabilities must be between 0 and 1.");
//             setResult(null);
//             return;
//         }

//         const probabilityRequest = {
//             probabilityA: parseFloat(probabilityA),
//             probabilityB: parseFloat(probabilityB),
//             operation
//         };
 
//         try {

//             const response = await axios.post(
//                 `${process.env.REACT_APP_API_BASE_URL}/api/probabilities/calculate`,
//                 probabilityRequest
//             );

//             setResult(response.data.result);
//             setError(null);

//         } catch (err) {
//             console.log('API Error:', err);
//             setError(err.response?.data || 'An error occurred');
//             setResult(null);
//         }
//     };

//     return (
//         <div className="container">
//             <h2>Probability Calculator</h2>
//             <form onSubmit={handleSubmit}>
//                 <div className="form-group">
//                     <label htmlFor="probabilityA">Probability A (0 - 1)</label>
//                     <input
//                         id="probabilityA"
//                         type="number"
//                         step="0.01"
//                         min="0"
//                         max="1"
//                         value={probabilityA}
//                         onChange={(e) => setProbabilityA(e.target.value)}
//                         required
//                     />
//                 </div>
//                 <div className="form-group">
//                     <label htmlFor="probabilityB">Probability B (0 - 1)</label>
//                     <input
//                         id="probabilityB"
//                         type="number"
//                         step="0.01"
//                         min="0"
//                         max="1"
//                         value={probabilityB}
//                         onChange={(e) => setProbabilityB(e.target.value)}
//                         required
//                     />
//                 </div>
//                 <div className="form-group">
//                     <label htmlFor="operation">Operation</label>
//                     <select
//                         id="operation"
//                         value={operation}
//                         onChange={(e) => setOperation(e.target.value)}
//                     >
//                         <option value="CombinedWith">Combined With</option>
//                         <option value="Either">Either</option>
//                     </select>
//                 </div>
//                 <button type="submit">Calculate</button>
//             </form>

//             <div data-testid="result" id="result" className="result">
//                 <h3>Result: {result}</h3>
//             </div>
//             {/* {result !== null && (
//                <div  id="result" className="result">
//                     <h3>Result: {result}</h3>
//                 </div>
//             )} */}

//             {error && (
//                 <div className="error">
//                     <h4>Error: {error}</h4>
//                 </div>
//             )}
//         </div>
//     );
// };

// export default ProbabilityCalculator;
