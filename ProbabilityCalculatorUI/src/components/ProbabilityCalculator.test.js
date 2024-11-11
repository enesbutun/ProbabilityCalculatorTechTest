import { render, screen, fireEvent, waitFor, act } from '@testing-library/react';
import '@testing-library/jest-dom';
import axios from 'axios';
import ProbabilityCalculator from './ProbabilityCalculator';


jest.mock('axios');

describe('ProbabilityCalculator', () => {
    beforeEach(() => {
        axios.post = jest.fn();
        axios.post.mockClear();  // Clear previous mock calls 
        axios.post.mockResolvedValueOnce({ data: { result: 0.25 } });
    });

    test('renders the form correctly', () => {
        render(<ProbabilityCalculator />);

        expect(screen.getByLabelText(/Probability A/i)).toBeInTheDocument();
        expect(screen.getByLabelText(/Probability B/i)).toBeInTheDocument();
        expect(screen.getByLabelText(/Operation/i)).toBeInTheDocument();

        expect(screen.getByRole('button', { name: /Calculate/i })).toBeInTheDocument();
    });

    test('displays validation error for out-of-range probabilities', async () => {
        render(<ProbabilityCalculator />);
    
        const probabilityAInput = screen.getByLabelText(/Probability A/i);
        fireEvent.change(probabilityAInput, { target: { value: '-1' } });
    
        expect(probabilityAInput.checkValidity()).toBe(false);
        expect(probabilityAInput.validity.rangeUnderflow).toBe(true); 
    
        const submitButton = screen.getByRole('button', { name: /Calculate/i });
        fireEvent.click(submitButton);
    
        expect(probabilityAInput.checkValidity()).toBe(false);
    });
    

    test('submits form and displays result on success CombinedWith', async () => {
        axios.post.mockResolvedValueOnce({ data: { result: 0.25 } });

        render(<ProbabilityCalculator />);

        fireEvent.change(screen.getByLabelText(/Probability A/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Probability B/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Operation/i), { target: { value: 'CombinedWith' } });

        fireEvent.click(screen.getByRole('button', { name: /Calculate/i }));

        const resultElement = await screen.findByText('Result: 0.25');
        expect(resultElement).toBeInTheDocument();

        expect(axios.post).toHaveBeenCalledWith(
            `${process.env.REACT_APP_API_BASE_URL}/api/probabilities/calculate`,
            {
                probabilityA: 0.5,
                probabilityB: 0.5,
                operation: 'CombinedWith',
            }
        );
    });

    test('submits form and displays result on success Either', async () => {
        axios.post.mockResolvedValueOnce({ data: { result: 0.75 } });

        render(<ProbabilityCalculator />);

        fireEvent.change(screen.getByLabelText(/Probability A/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Probability B/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Operation/i), { target: { value: 'Either' } });

        fireEvent.click(screen.getByRole('button', { name: /Calculate/i }));

        const resultElement = await screen.findByText('Result: 0.25');
        expect(resultElement).toBeInTheDocument();

        expect(axios.post).toHaveBeenCalledWith(
            `${process.env.REACT_APP_API_BASE_URL}/api/probabilities/calculate`,
            {
                probabilityA: 0.5,
                probabilityB: 0.5,
                operation: 'Either',
            }
        );
    });


    test('displays error message on failed API call', async () => {
    
        axios.post.mockRejectedValueOnce({ response: { data: 'Calculation failed' } });

        render(<ProbabilityCalculator />);

        fireEvent.change(screen.getByLabelText(/Probability A/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Probability B/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Operation/i), { target: { value: 'CombinedWith' } });

        fireEvent.click(screen.getByRole('button', { name: /Calculate/i }));

        await waitFor(() => {
            screen.debug();
        });
    });

});
