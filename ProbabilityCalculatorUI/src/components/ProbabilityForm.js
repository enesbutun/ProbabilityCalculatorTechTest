import React, { useState } from 'react';

const ProbabilityForm = ({ onSubmit }) => {
    const [probabilityA, setProbabilityA] = useState('');
    const [probabilityB, setProbabilityB] = useState('');
    const [operation, setOperation] = useState('CombinedWith');

    const handleSubmit = (e) => {
        e.preventDefault();
        
        if (probabilityA < 0 || probabilityA > 1 || probabilityB < 0 || probabilityB > 1) {
            alert("Probabilities must be between 0 and 1.");
            return;
        }

        onSubmit(parseFloat(probabilityA), parseFloat(probabilityB), operation);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div className="form-group">
                <label htmlFor="probabilityA">Probability A (0 - 1)</label>
                <input
                    id="probabilityA"
                    type="number"
                    step="0.01"
                    min="0"
                    max="1"
                    value={probabilityA}
                    onChange={(e) => setProbabilityA(e.target.value)}
                    required
                />
            </div>
            <div className="form-group">
                <label htmlFor="probabilityB">Probability B (0 - 1)</label>
                <input
                    id="probabilityB"
                    type="number"
                    step="0.01"
                    min="0"
                    max="1"
                    value={probabilityB}
                    onChange={(e) => setProbabilityB(e.target.value)}
                    required
                />
            </div>
            <div className="form-group">
                <label htmlFor="operation">Operation</label>
                <select
                    id="operation"
                    value={operation}
                    onChange={(e) => setOperation(e.target.value)}
                >
                    <option value="CombinedWith">Combined With</option>
                    <option value="Either">Either</option>
                </select>
            </div>
            <button type="submit">Calculate</button>
        </form>
    );
};

export default ProbabilityForm;
