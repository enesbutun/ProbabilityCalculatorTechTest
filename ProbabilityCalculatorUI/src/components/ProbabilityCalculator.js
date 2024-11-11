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

