import React from 'react';

const ResultDisplay = ({ result, error }) => {
    return (
        <div>
            {result !== null && (
                <div data-testid="result" id="result" className="result">
                    <h3>Result: {result}</h3>
                </div>
            )}
            {error && (
                <div className="error">
                    <h4>Error: {error}</h4>
                </div>
            )}
        </div>
    );
};

export default ResultDisplay;
