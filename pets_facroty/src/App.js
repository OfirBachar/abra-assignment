import React, { useState } from 'react';
import './App.css';

const App = () => {
  const [name, setName] = useState('');
  const [color, setColor] = useState('#000000');
  const [age, setAge] = useState('');
  const [type, setType] = useState('dog');

  const handleSubmit = async (e) => {
    e.preventDefault();
    const petData = { name, color, age: parseInt(age), type };

    try {
      const response = await fetch('http://localhost:5231/api/pets', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(petData),
      });

      if (response.ok) {
        console.log('Pet added successfully!');
        setName('');
        setColor('#000000');
        setAge('');
        setType('dog');
      } else {
        console.error('Failed to add pet.');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <div className='App'>
      <h2>Pets Factory</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>
            Name:
            <input
              type='text'
              value={name}
              onChange={(e) => setName(e.target.value)}
              maxLength={25}
              required
            />
          </label>
        </div>
        <div>
          <label>
            Color:
            <input
              type='color'
              value={color}
              onChange={(e) => setColor(e.target.value)}
              required
            />
          </label>
        </div>
        <div>
          <label>
            Age:
            <input
              type='number'
              value={age}
              onChange={(e) => setAge(e.target.value)}
              max={20}
              required
            />
          </label>
        </div>
        <div>
          <label>
            Type:
            <select
              value={type}
              onChange={(e) => setType(e.target.value)}
              required
            >
              <option value='dog'>Dog</option>
              <option value='cat'>Cat</option>
              <option value='horse'>Horse</option>
              <option value='other'>Other</option>
            </select>
          </label>
        </div>
        <button type='submit'>Submit</button>
      </form>
    </div>
  );
};

export default App;
